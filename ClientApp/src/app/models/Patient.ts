export interface Patient {
  Id: Number;
  DoctorId: Number;
  KinId: Number;
  FirstName: String;
  LastName: String;
  FullName: String;
  PassNo: String;
  MobileNumber: String;
  DateOfBirth: Date;
  Gender: GenderCode;
}
export enum GenderCode {
  M,
  F,
}
