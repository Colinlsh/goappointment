import {
  createAsyncThunk,
  createSlice,
  PayloadAction,
  Slice,
  SliceCaseReducers,
} from '@reduxjs/toolkit';
import axios from 'axios';
import { string } from 'yup/lib/locale';
import { ApplicationState } from '../../models';
import {
  AppointmentDto,
  AppointmentState,
} from '../../models/appointmentModel';

// #region Async thunk
export const getAvaliableTimeslots = createAsyncThunk(
  'appointment/getAvaliableTimeslots',
  async () => {
    return await axios.get('appointment/list', {});
  }
);

export const postAppointment = createAsyncThunk(
  'appointment/postAppointment',
  async (appointmentDto: AppointmentDto) => {
    return await axios.post('appointment/create', appointmentDto);
  }
);
// #endregion

const appointmentSlice: Slice<
  AppointmentState,
  SliceCaseReducers<AppointmentState>,
  'application'
> = createSlice({
  name: 'application',
  initialState: {
    appointments: [],
    error: '',
  } as AppointmentState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(getAvaliableTimeslots.fulfilled, (state, action) => {
        state.appointments = action.payload.payload;
      })
      .addCase(getAvaliableTimeslots.rejected, (state, { payload }) => {
        state.error = '';
      });
  },
});

export const { setRefView, setCommonModal, toggleCommonModal } =
  appointmentSlice.actions;

export default appointmentSlice.reducer;
