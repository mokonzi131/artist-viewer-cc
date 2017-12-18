import { Component, Inject } from '@angular/core';

@Component({
    template: `<h2>Logging out...</h2>`
})
export class LogoutComponent {
    constructor( @Inject('BASE_URL') baseUrl: string) {
        document.location.href = baseUrl + 'Account/Logout';
    }
}