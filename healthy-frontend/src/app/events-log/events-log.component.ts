import { Component, OnInit, ViewChild, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpService } from '../http.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';


export interface EventsLogData {
  logged: Date;
  eventTypeId: number;
  eventTypeName: string;
  milliliters: number;
  walkingDistance: number;
  timeElapsed: number;
  calories: number;
  score: number;
}

export interface UserData {
  name: string;
  location: string;
  country: string;
  email: string;
}

@NgModule({
  imports: [
    FormsModule,
    CommonModule
  ],
  declarations: [
    EventsLogComponent
  ]
})

@Component({
  selector: 'app-events-log',
  templateUrl: './events-log.component.html',
  styleUrls: ['./events-log.component.scss']
})


export class EventsLogComponent implements OnInit {
  displayedColumns: string[] = ['logged', 'eventTypeName', 'milliliters', 'walkingDistance', 'timeElapsed', 'calories', 'score'];
  displayedFields: string[] = ['name', 'location', 'country', 'email'];
  dataSource: MatTableDataSource<EventsLogData>;
  //userData: MatTableDataSource<UserData>;
  userData: any;
  eventsLog: any;
  user: any;
  userId: any;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private httpSvc: HttpService) {
    this.userId = 1;
    this.httpSvc.getEventsLog(this.userId).subscribe(data => {
      this.eventsLog = data;
      this.dataSource = new MatTableDataSource(this.eventsLog);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
      console.log(this.dataSource);
    });

    this.httpSvc.getUser(this.userId).subscribe(data => {
      this.user = data;
      //this.userData = new MatTableDataSource(this.user);
      this.userData = this.user;
      console.log(this.userData);
    });
  }
  // TODO: Move code above to ngOnInit()

  ngOnInit() {
    /*this.httpSvc.getEventsLog().subscribe(data => {
      this.eventsLog = data;
      console.log(this.eventsLog);
    });*/
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}


