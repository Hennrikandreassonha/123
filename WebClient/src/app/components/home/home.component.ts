import { Component } from '@angular/core';
import { User } from 'src/app/Classes/User';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  constructor(private _userService: UserService) {

  }

  createUser() {
    const user: User = new User("Henke", "testmail@mail.com", "123");

    this._userService.createUser(user).
      subscribe({
        next: (res) => {
          console.log(res);
        },
        error: (err) => {
          console.log(err);
        }
      });
  }
}
