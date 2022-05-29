import { HttpClient, HttpParams } from '@angular/common/http';
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
  deletePatient(patient: Patient) {
    if (patient.Id) {
      let params = new HttpParams().set('Id', patient.Id);
      return this.http
        .delete<Number>(this.baseUrl + 'clinic', { params })
        .toPromise();
    }
    return new Promise((resolve, reject) => {
      reject('Patient ID is required');
    });
  }
}
