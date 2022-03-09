import { configureStore, ThunkAction, Action } from '@reduxjs/toolkit';
import applicationSlice from './slice/applicationSlice';
import storeSlice from './slice/storeSlice';

export const store = configureStore({
  reducer: {
    application: applicationSlice,
    store: storeSlice,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      serializableCheck: false,
    }),
});

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  Action<string>
>;
