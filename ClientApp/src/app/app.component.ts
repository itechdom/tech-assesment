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
  newPatient: Patient = {
    FirstName: '',
    LastName: '',
    DateOfBirth: new Date(),
    Gender: GenderCode.M,
    Kin: {},
  };
  editPatientForm: boolean = false;
  editedPatient: any = {};

  constructor(private patientService: PatientService) {}

  ngOnInit() {
    this.getPatients().then((data) => {
      this.patients = data;
    });
    this.patientService.getDoctors().then((data) => {
      console.log('Doctors', data);
    });
  }

  getEmptyPatient(): Patient {
    return {
      FirstName: '',
      LastName: '',
      DateOfBirth: new Date(),
      Gender: GenderCode.M,
      Kin: {},
    };
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
      this.newPatient = this.getEmptyPatient();
    }
    this.patientForm = true;
    this.isNewPatient = true;
  }

  savePatient(patient: Patient) {
    console.log('NEW', patient);
    let newPatient: Patient = {
      FirstName: patient.FirstName,
      LastName: patient.LastName,
      DateOfBirth: new Date(),
      MobileNumber: '05019777777',
      Gender: GenderCode.M,
      Kin: {
        FirstName: patient.Kin.FirstName,
        LastName: patient.Kin.LastName,
        Relation: Relationship.Other,
      },
    };
    this.patientService.addPatient(newPatient).then((data) => {
      console.log('DATA', data);
      newPatient.Id = data as number;
      this.patients.push(newPatient);
    });
    this.patientForm = false;
  }

  updatePatient() {
    this.editPatientForm = false;
    this.editedPatient = {};
  }

  removePatient(patient: Patient) {
    this.patientService.deletePatient(patient).then((data) => {
      this.patients = this.patients.filter((p) => p.Id != patient.Id);
    });
  }

  cancelEdits() {
    this.editedPatient = {};
    this.editPatientForm = false;
  }

  cancelNewPatient() {
    this.newPatient = this.getEmptyPatient();
    this.patientForm = false;
  }
}
