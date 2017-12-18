import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    templateUrl: './artists.component.html'
})
export class ArtistsComponent {
    public artists: ArtistData[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/artists').subscribe(result => {
            this.artists = result.json() as ArtistData[];
        }, error => console.error(error));
    }
}

interface ArtistData {
    id: string;
    name: string;
    imageUrl: string;
    artistUrl: string;
}