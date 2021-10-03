import { Component } from '@angular/core';
import { HttpService } from './services/http.service';
import { myClass } from './_interfaces/myClass.model';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public selectedClass: myClass;
  public studentsNameList : string[]
  public showTable: boolean
  constructor(private httpService: HttpService){}
  onClickedOutside(e: Event) {
    this.showTable = false;
  }

  onKeyUp(e: Event) { // appending the updated value to the variable
    this.showTable = false;
  }
  public getClass1 = () => {
    let route: string = 'https://localhost:44303/api/classitems/1';
    this.httpService.getData(route)
    .subscribe((result) => {
      this.selectedClass = result as myClass;
      this.studentsNameList = this.selectedClass.studentsNames.split(",");
      this.showTable = true;
    },
    (error) => {
      console.error(error);
    });
    
  }
  public getClass2 = () => {
    let route: string = 'https://localhost:44303/api/classitems/2';
    this.httpService.getData(route)
    .subscribe((result) => {
      this.selectedClass = result as myClass;
      this.studentsNameList = this.selectedClass.studentsNames.split(",");
      this.showTable = true;
    },
    (error) => {
      console.error(error);
    });

  }
}


