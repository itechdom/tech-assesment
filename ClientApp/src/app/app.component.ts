import { Component, OnInit } from '@angular/core';
import { Relationship } from './models/Kin';
import { GenderCode, Patient } from './models/Patient';
import { PatientService } from './services/patient.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  patients: Patient[] = [];
  patientForm: boolean = false;
  isNewPatient: boolean = false;
  newPatient: any = {};
  editPatientForm: boolean = false;
  editedPatient: any = {};

  constructor(private patientService: PatientService) {}

  ngOnInit() {
    this.getPatients().then((data) => {
      this.patients = data;
    });
    this.patientService.getDoctors().then((data) => {
      console.log('data', data);
    });
    this.patientService.addPatient({
      FirstName: "test",
      LastName: "test2",
      DateOfBirth: new Date(),
      Gender: GenderCode.M,
      Kin:{
        Id: 0,
        FirstName: "Kin test 1",
        LastName: "Kin test 2",
        Relation: Relationship.Other,
      }
    })
  }

  async getPatients(): Promise<Patient[]> {
    const pt = await this.patientService.getPatients();
    return pt;
  }

  showEditPatientForm(patient: Patient) {
    if (!patient) {
      this.patientForm = false;
      return;
    }
    this.editPatientForm = true;
    this.editedPatient = patient;
  }

  showAddPatientForm() {
    // resets form if edited patient
    if (this.patients.length) {
      this.newPatient = {};
    }
    this.patientForm = true;
    this.isNewPatient = true;
  }

  savePatient(patient: Patient) {
    if (this.isNewPatient) {
      // add a new patient
      this.patientService.addPatient(patient);
    }
    this.patientForm = false;
  }

  updatePatient() {
    this.patientService.updatePatient(this.editedPatient);
    this.editPatientForm = false;
    this.editedPatient = {};
  }

  removePatient(patient: Patient) {
    this.patientService.deletePatient(patient);
  }

  cancelEdits() {
    this.editedPatient = {};
    this.editPatientForm = false;
  }

  cancelNewPatient() {
    this.newPatient = {};
    this.patientForm = false;
  }
}
