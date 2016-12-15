import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'divelog',
    template: require('./divelog.component.html')
})
export class DiveLogComponent {
    public index = 0;
    public dives: Dive[] = new Array();
    public allDives: Dive[] = new Array();

    constructor(http: Http) {
        http.get('/api/SampleData/Dives').subscribe(result => {
                this.allDives = result.json();
            });
    }
    public addDive() {
        if (this.enableAdd()) {
            this.dives.push(this.allDives[this.index++])
        }
    }
    public clearDives() {
        this.dives = [];
        this.index = 0;
    }
    public enableAdd() {
        return this.index < this.allDives.length;
    }
}
interface Dive {
    site: string;
    location: string;
    depth: number;
    time: number;
}
