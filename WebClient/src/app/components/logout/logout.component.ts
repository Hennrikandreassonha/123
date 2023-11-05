import { Component, NgZone } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Services/auth.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent {
  constructor(private router: Router,
    private _authService: AuthService,
    private _ngZone: NgZone
  ){

  }

  ngOnInit(): void {

  }

  handleLogout(){
    this._authService.signOutExternal();
    this._ngZone.run(() => {
      this.router.navigate(['']).then (() => window.location.reload())
    })
  }
}
