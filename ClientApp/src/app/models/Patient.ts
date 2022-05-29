import { Doctor } from './Doctor';
import { Kin } from './Kin';

export interface Patient {
  Id?: Number;
  Kin: Kin;
  Doctor?: Doctor;
  FirstName: String;
  LastName: String;
  FullName?: String;
  PassNo?: String;
  MobileNumber?: String;
  DateOfBirth: Date;
  Gender: GenderCode;
}
export enum GenderCode {
  M,
  F,
}
