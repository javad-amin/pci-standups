import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-stand-up',
  templateUrl: './stand-up.component.html',
  styleUrls: ['./stand-up.component.css']
})
export class StandUpComponent {
  baseUrl: string;
  StandUp: any;
  jsonBody = "";
  response: any;
  maxTeamSize: Array<number>;
  minimumAttendees: number = 0;

  
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    this.baseUrl = baseUrl;
    this.maxTeamSize = [];
    for (let i = 1; i < 17; i++) {
      this.maxTeamSize.push(i);   
    }
  }

  minimumAttendeesHandler (event: any) {
    this.minimumAttendees = event.target.value;
  }

  postData() {
    this.http.post(this.baseUrl + 'standup/' + this.minimumAttendees, JSON.parse(this.jsonBody)).toPromise().then((data:any) => {
      this.response = data;
    });
  }
}
