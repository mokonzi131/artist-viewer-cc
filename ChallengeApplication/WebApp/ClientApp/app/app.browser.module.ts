import { NgModule } from '@angular/core';
import { BrowserModule, DOCUMENT } from '@angular/platform-browser';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';

declare const document: Document;

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        BrowserModule,
        AppModuleShared
    ],
    providers: [
        { provide: 'BASE_URL', useFactory: getBaseUrl }
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
