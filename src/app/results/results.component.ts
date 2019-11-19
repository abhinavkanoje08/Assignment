import { Component, OnInit, Input } from '@angular/core';
import { ClientApiService } from '../client-api.service';
import { IClients } from '../Clients';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.scss']
})
export class ResultsComponent implements OnInit {


  @Input() clientList;



  constructor(private clientService: ClientApiService) { }

  ngOnInit() {


  }


}
