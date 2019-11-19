import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { ResultsComponent } from '../results/results.component';
import { IClients } from '../Clients';
import { ClientApiService } from '../client-api.service';
@Component({
  selector: 'app-top-menu',
  templateUrl: './top-menu.component.html',

  styleUrls: ['./top-menu.component.scss']
})
export class TopMenuComponent implements OnInit {



  clients = new IClients();

  clientList = [];
  constructor(private pr: ClientApiService) { }

  ngOnInit() {

  }

  printResult() {
    this.pr.printResult(this.clients)
      .subscribe(r => {
        this.clientList = r;
      })
  }



}
