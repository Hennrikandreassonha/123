import { Component, NgZone, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Services/auth.service';
import { CredentialResponse, PromptMomentNotification } from 'google-one-tap';

declare var google: any;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements AfterViewInit {

  constructor(
    private router: Router,
    private authService: AuthService,
    private ngZone: NgZone
  ) {}

  ngAfterViewInit(): void {
    this.loadGoogleLibrary(() => {
      google.accounts.id.initialize({
        client_id: '199796154632-go57va210rlgld0g6l2dnc4m746s93f4.apps.googleusercontent.com',
        callback: this.handleCredentialResponse.bind(this),
        auto_select: false,
        cancel_on_tap_outside: true
      });
      google.accounts.id.renderButton(
        document.getElementById('buttonDiv'),
        { theme: 'outline', size: 'large', width: '200px' }
      );
      google.accounts.id.prompt((notification: PromptMomentNotification) => {});
    });
  }

  private loadGoogleLibrary(callback: () => void): void {
    const script = document.createElement('script');
    script.src = 'https://accounts.google.com/gsi/client';
    script.onload = callback;
    document.head.appendChild(script);
  }

  async handleCredentialResponse(response: CredentialResponse) {
    try {
      const x: any = await this.authService.googleLogin(response.credential).toPromise();
      localStorage.setItem('token', x.token);
      this.ngZone.run(() => {
        this.router.navigate(['']);
      });
    } catch (err) {
      console.error(err);
    }
  }
}
