import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Subject } from 'rxjs/Subject';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/combineLatest';

import { IArtistData, ArtistService } from '../../services/artist.service';

@Component({
    templateUrl: './artists.component.html'
})
export class ArtistsComponent {
    public artists: IArtistData[];
    public searchText: string;
    public shouldFilter: boolean;

    private _searchTextSubject = new Subject<string>();
    private _shouldFilterSubject = new Subject<boolean>();

    constructor(private _service: ArtistService) { }

    ngOnInit() {
        // load initial data set into the grid
        this._service.ArtistCache.subscribe(artists => this.artists = artists);

        // react to changes in search text
        let searchFilter = this._searchTextSubject
            .debounceTime(250)
            .distinctUntilChanged();

        // react to changes in filter
        let commentsFilter = this._shouldFilterSubject
            .distinctUntilChanged();

        // chain filters and seed initial values (for combineLatest)
        searchFilter.combineLatest(commentsFilter).subscribe(([searchTerm, filterComments]) => {
            this._service.ArtistCache.subscribe(artists => {
                let filteredArtists = artists
                    .filter(artist => filterComments ? artist.comments > 0 : true)
                    .filter(artist => artist.name.toLowerCase().includes(searchTerm));
                this.artists = filteredArtists;
            });
        });
        this._searchTextSubject.next("");
        this._shouldFilterSubject.next(false);
    }

    public handleSearchTextChanged() {
        let searchTerm = this.searchText.trim().toLowerCase();
        this._searchTextSubject.next(searchTerm);
    }

    public handleFilterChanged() {
        this._shouldFilterSubject.next(this.shouldFilter);
    }
}

