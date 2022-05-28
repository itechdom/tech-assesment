import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
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
    this.getPatients();
  }
  getPatients(): Promise<Patient[]> {
    return this.http.get<Patient[]>(this.baseUrl + 'clinic').toPromise();
  }
  addPatient(user: Patient) {}
  updatePatient(user: Patient) {}
  deletePatient(user: Patient) {}
}
