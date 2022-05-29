export enum Relationship {
  Daughter,
  Son,
  Mother,
  Father,
  Husband,
  Wife,
  Other,
}
export interface Kin {
  Id?: Number;
  FirstName?: String;
  LastName?: String;
  FullName?: String;
  AddressLineOne?: String;
  AddressLineTwo?: String;
  AddressLineThree?: String;
  AddressLineFour?: String;
  Relation?: Relationship;
}
