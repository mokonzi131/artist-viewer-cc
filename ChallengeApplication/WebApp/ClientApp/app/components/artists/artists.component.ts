import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';

import { IArtistData, ArtistService } from '../../services/artist.service';

@Component({
    templateUrl: './artists.component.html'
})
export class ArtistsComponent {
    public artists: IArtistData[];
    public searchText: string;

    private _searchTextSubject = new Subject<string>();

    constructor(private _service: ArtistService) { }

    ngOnInit() {
        // load initial data set into the grid
        this._service.ArtistCache.subscribe(artists => this._loadGrid(artists));

        // react to changes in search text
        let searchFilter = this._searchTextSubject
            .debounceTime(250)
            .distinctUntilChanged();

        // apply filters to artists cache
        searchFilter.subscribe(searchTerm => {
            this._service.ArtistCache.subscribe(artists => {
                this._loadGrid(artists.filter(artist => artist.name.includes(searchTerm)));
            });
        });
    }

    public handleSearchTextChanged() {
        let searchTerm = this.searchText.trim();
        this._searchTextSubject.next(searchTerm);
    }

    private _loadGrid(artists: IArtistData[]) {
        this.artists = artists;
    }
}

