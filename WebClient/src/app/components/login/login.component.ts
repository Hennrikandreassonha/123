import { Component, NgZone } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/Services/auth.service';
import { CredentialResponse, PromptMomentNotification } from 'google-one-tap';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(private router: Router,
    private authService: AuthService,
    private ngZone: NgZone
  ) {

  }

  ngOnInit(): void {
    // @ts-ignore
    window.onGoogleLibraryLoad = () => {
      // @ts-ignore
      google.accounts.id.initialize({
        client_id: '199796154632-go57va210rlgld0g6l2dnc4m746s93f4.apps.googleusercontent.com',
        callback: this.handleCredentialResponse.bind(this),
        auto_select: false,
        cancel_on_tap_outside: true
      });
      // @ts-ignore
      google.accounts.id.renderButton(
        // @ts-ignore
        document.getElementById('buttonDiv'),
        { theme: 'outline', size: 'large', width: '200px' }
      );
      // @ts-ignore
      google.accounts.id.prompt((notification: PromptMomentNotification) => {});
    }
    console.log("tja")
  }

  async handleCredentialResponse(response: CredentialResponse) {
    await this.authService.googleLogin(response.credential).
      subscribe(
        (x: any) => {
          localStorage.setItem('token', x.token);
          this.ngZone.run(() => {
            this.router.navigate([''])
          })
        },
        (err: any) => {
          console.log(err)
        }
      )
  }
}
