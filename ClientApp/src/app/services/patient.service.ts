import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Doctor } from '../models/Doctor';
import { Patient } from '../models/Patient';

@Injectable({
  providedIn: 'root',
})
export class PatientService {
  baseUrl: string;
  http: HttpClient;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }
  getPatients(): Promise<Patient[]> {
    return this.http.get<Patient[]>(this.baseUrl + 'clinic').toPromise();
  }
  getDoctors(): Promise<Doctor[]> {
    return this.http.get<Doctor[]>(this.baseUrl + 'clinic/doctors').toPromise();
  }
  addPatient(patient: Patient): Promise<Number> {
    return this.http.post<Number>(this.baseUrl + 'clinic', patient).toPromise();
  }
  updatePatient(patient: Patient) {}
  deletePatient(patient: Patient) {}
}
