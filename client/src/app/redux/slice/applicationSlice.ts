import {
  createSlice,
  PayloadAction,
  Slice,
  SliceCaseReducers,
} from '@reduxjs/toolkit';
import { ApplicationState } from '../../models';

const applicationSlice: Slice<
  ApplicationState,
  SliceCaseReducers<ApplicationState>,
  'application'
> = createSlice({
  name: 'application',
  initialState: {
    refViews: [],
    commonModal: { title: '', message: [], isVisible: false },
    error: '' as string,
  } as ApplicationState,
  reducers: {
    setRefView: (state, action) => {
      state.refViews = [
        ...state.refViews.filter((x) => x.name !== action.payload.name),
        action.payload,
      ];
    },
    setCommonModal: (state, action) => {
      state.commonModal = action.payload;
    },
    toggleCommonModal: (state, action: PayloadAction<boolean>) => {
      state.commonModal.isVisible = action.payload;
    },
  },
});

export const { setRefView, setCommonModal, toggleCommonModal } =
  applicationSlice.actions;

export default applicationSlice.reducer;
