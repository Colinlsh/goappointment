import {
  createAsyncThunk,
  createSlice,
  PayloadAction,
  Slice,
  SliceCaseReducers,
} from '@reduxjs/toolkit';
import { WritableDraft } from '@reduxjs/toolkit/node_modules/immer/dist/types/types-external';
import { Guid } from 'guid-typescript';
import moment from 'moment';
import agent from '../../api/agent';
import { TimeDifference } from '../../common/utils/utils';
import { ProcessLoadingState, TimeType } from '../../models';
import { StoreDto, StoreInfoModel, StoreState } from '../../models/storeModel';
import { store } from '../store';
import { FulfilledAction, PendingAction, RejectedAction } from '../types';

// #region Async thunk
export const getStore = createAsyncThunk('store/getStore', async () => {
  const response = await agent.Store.details();

  return response;
});
// #endregion

const storeSlice: Slice<
  StoreState,
  SliceCaseReducers<StoreState>,
  'store'
> = createSlice({
  name: 'store',
  initialState: {
    store: {
      id: Guid.parse(Guid.EMPTY),
      storeName: '',
      address: '',
      operatingStartHour: 0,
      operatingStartMinutes: 0,
      operatingEndHour: 0,
      operatingEndMinutes: 0,
      isOpenOnSaturday: false,
      isOpenOnSunday: false,
      isOpenOnWeekends: false,
      serviceHoursPerHour: 0,
      storeOffDaysDtos: [],
      storeSpecialOffsDtos: [],
    },
    storeInfo: {
      disabledDates: [],
      disabledSpecialDates: [],
      disabledDays: [],
      totalWorkingHours: 0,
      timeslots: [],
    },
    state: ProcessLoadingState.START,
    error: {},
  } as StoreState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(getStore.fulfilled, (state, action: PayloadAction<StoreDto>) => {
        state.store = action.payload;
        ConstructStoreOffDays(state, action);

        const totalWorkingHours = CalculateWorkingHours(state)!;

        state.storeInfo.totalWorkingHours = totalWorkingHours;

        const timeSlots = Array<Date>();
        const startTime = new Date(
          2021,
          1,
          1,
          state.store.operatingStartHour,
          state.store.operatingStartMinutes
        );

        var newTimeslot = startTime;

        for (let index = 0; index < totalWorkingHours / 60; index++) {
          timeSlots.push(newTimeslot);
          newTimeslot = moment.utc(newTimeslot).add(60, 'm').toDate();
        }
        state.storeInfo.timeslots = [];
        state.storeInfo.timeslots = state.storeInfo.timeslots.concat(timeSlots);
      })
      .addCase(getStore.rejected, (state, action) => {
        state.error = action.error;
      })
      .addMatcher<RejectedAction>(
        (action) => action.type.endsWith('/rejected'),
        (state, action) => {
          state.state = ProcessLoadingState.FAIL;
        }
      )
      .addMatcher<FulfilledAction>(
        (action) => action.type.endsWith('/fulfilled'),
        (state, action) => {
          state.state = ProcessLoadingState.COMPLETE;
        }
      )
      .addMatcher<PendingAction>(
        (action) => action.type.endsWith('/pending'),
        (state, action) => {
          state.state = ProcessLoadingState.LOADING;
        }
      );
  },
});

export const {} = storeSlice.actions;

export default storeSlice.reducer;

const ConstructStoreOffDays = (
  state: WritableDraft<StoreState>,
  action: { payload: StoreDto; type: string }
) => {
  state.storeInfo.disabledDays = Array<number>();
  state.storeInfo.disabledDates = Array<Date>();
  state.storeInfo.disabledSpecialDates = Array<Date>();

  // store days settings
  var _disabledDays = Array<number>();
  if (!action.payload.isOpenOnSaturday) _disabledDays.push(6);
  if (!action.payload.isOpenOnSunday) _disabledDays.push(0);
  if (!action.payload.isOpenOnWeekends) {
    const newDates = _disabledDays.filter((x) => x !== 6 && x !== 0);
    _disabledDays = [...newDates, 6, 0];
  }

  state.storeInfo.disabledDays =
    state.storeInfo.disabledDays.concat(_disabledDays);

  // store offdays
  action.payload.storeOffDaysDtos!.map((x) =>
    state.storeInfo.disabledDates.push(x.offDay)
  );

  // store specialoffdays
  action.payload
    .storeSpecialOffsDtos!.filter((x) => !x.isDaily)
    .map((x) => state.storeInfo.disabledSpecialDates.push(x.offDateTime));
};
function CalculateWorkingHours(state: WritableDraft<StoreState>) {
  return TimeDifference(
    new Date(
      2020,
      1,
      1,
      state.store.operatingEndHour,
      state.store.operatingEndMinutes
    ),
    new Date(
      2020,
      1,
      1,
      state.store.operatingStartHour,
      state.store.operatingStartMinutes
    ),
    TimeType.Minutes
  );
}
