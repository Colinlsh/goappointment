import { SerializedError } from '@reduxjs/toolkit';
import { Guid } from 'guid-typescript';
import { ProcessLoadingState } from '../common/utils/enums';

export interface StoreState {
  store: StoreDto;
  storeInfo: StoreInfoModel;
  state: ProcessLoadingState;
  error: SerializedError;
}

export interface StoreInfoModel {
  disabledDates: Array<Date>;
  disabledSpecialDates: Array<Date>;
  disabledDays: Array<number>;
  totalWorkingHours: number;
  timeslots: Array<Date>;
}

export interface StoreDto {
  id: Guid;
  storeName: string;
  address: string;
  operatingStartHour: number;
  operatingStartMinutes: number;
  operatingEndHour: number;
  operatingEndMinutes: number;
  isOpenOnSaturday: boolean;
  isOpenOnSunday: boolean;
  isOpenOnWeekends: boolean;
  serviceHoursPerHour: number;
  storeOffDaysDtos: Array<StoreOffDaysDto>;
  storeSpecialOffsDtos: Array<StoreSpecialOffsDto>;
}

export interface StoreOffDaysDto {
  id: Guid;
  offDay: Date;
  description: string;
}

export interface StoreSpecialOffsDto {
  id: Guid;
  description: string;
  offDateTime: Date;
  offStartHour: number;
  offStartMinutes: number;
  offEndHour: number;
  offEndMinutes: number;
  isDaily: boolean;
}
