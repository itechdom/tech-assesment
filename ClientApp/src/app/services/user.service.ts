import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private upersons: User[] = [
    {
      id: 1,
      firstName: 'Durgesh',
      lastName: 'Pal',
    },
    {
      id: 2,
      firstName: 'Ankur',
      lastName: 'Pal',
    },
  ];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<User[]>(baseUrl + 'clinic').subscribe(
      (result: User[]) => {
        console.log('result', result);
      },
      (error: any) => console.error(error)
    );
  }

  getUsersFromData(): User[] {
    return this.upersons;
  }

  addUser(user: User) {
    user.id = this.upersons.length + 1;
    this.upersons.push(user);
  }
  updateUser(user: User) {
    const index = this.upersons.findIndex((u) => user.id === u.id);
    this.upersons[index] = user;
  }
  deleteUser(user: User) {
    this.upersons.splice(this.upersons.indexOf(user), 1);
  }
}
