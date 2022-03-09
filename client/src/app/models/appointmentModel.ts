import { Guid } from 'guid-typescript';

export interface AppointmentState {
  appointments: Array<AppointmentDto>;
  error: string;
}

export interface AppointmentDto {
  appointmentId: Guid;
  title: string;
  description: string;
  bookDate: Date;
  appointmentStatus: string;
  telegramCustomerProfiles: Array<TelegramCustomerProfileDto>;
  CustomerProfiles: Array<CustomerProfileDto>;
  serviceDtos: Array<ServiceDto>;
}

export interface TelegramCustomerProfileDto {}
export interface CustomerProfileDto {}
export interface ServiceDto {}
