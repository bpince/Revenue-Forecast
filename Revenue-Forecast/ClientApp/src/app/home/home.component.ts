import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { INumberKeyValue } from '../client-revenue/client/client.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  private currentMonthlyProjects: IClientRevenueDisplayModel[] = [];
  private searchFields: INumberKeyValue[] = [];
  private searchField: number = 1;
  private searchTerm: string;

  constructor(
    private httpClient: HttpClient
  ) {

    //get monthly projects
    httpClient
      .get<IClientRevenueDisplayModel[]>('/api/clientrevenue/getmonthlyprojects')
      .subscribe(result => this.currentMonthlyProjects = result);

    //get search fields
    httpClient
      .get<INumberKeyValue[]>('/api/data/getsearchfields')
      .subscribe(result => this.searchFields = result);
  }

  getTotalRevenue() {

    return this.currentMonthlyProjects
      .map(c => c.netRevenue)
      .reduce((acc, cur) => acc + cur, 0);
  }

  searchProjects() {

    this.httpClient
      .get<IClientRevenueDisplayModel[]>('/api/clientrevenue/getmonthlyprojects',
        {
          params: {
            'search': this.searchField.toString(),
            'searchTerm': this.searchTerm
          }
        })
    .subscribe(result => this.currentMonthlyProjects = result);
  }

}

interface IClientRevenueDisplayModel {
  id: number;
  clientName: string;
  projectName: string;
  jobNumber: number;
  statusName: string;
  netRevenue: number;
}
