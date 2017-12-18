import { Injectable, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

export interface IArtistData {
    id: string;
    name: string;
    imageUrl: string;
    artistUrl: string;
}

@Injectable()
export class ArtistService {
    private static readonly RESOURCE = "api/artists";

    private _artistsCache = new BehaviorSubject<IArtistData[]>([]);

    public get ArtistCache(): Observable<IArtistData[]> {
        return this._artistsCache;
    }

    constructor(private _http: Http, @Inject('BASE_URL') private _baseUrl: string) {
        this._loadArtists().subscribe(artists => {
            this._artistsCache.next(artists);
        });
    }

    private _loadArtists(): Observable<IArtistData[]> {
        return this._http
            .get(this._baseUrl + ArtistService.RESOURCE)
            .map(result => {
                return result.json() as IArtistData[];
            })
            .catch(this._handleApiError);
    }

    private _handleApiError(error: Response | any) {
        console.error('ArtistService::ApiError', error);
        return Observable.throw(error);
    }
}