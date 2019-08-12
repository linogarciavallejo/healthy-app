import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-events-log',
  templateUrl: './events-log.component.html',
  styleUrls: ['./events-log.component.scss']
})
export class EventsLogComponent implements OnInit {

  eventsLog: Object;

  constructor(private httpSvc: HttpService) { }

  ngOnInit() {
    this.httpSvc.getEventsLog().subscribe(data => {
      this.eventsLog = data;
      console.log(this.eventsLog);
    });
  }

}
