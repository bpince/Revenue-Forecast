import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'client-component',
  templateUrl: './client.component.html'
})
export class ClientComponent implements OnInit {

  id: number;
  result: boolean;
  clientRevenue: IClientRevenue;
  months: INumberKeyValue[];
  statuses: INumberKeyValue[];
  errorMessage: string = '';

  constructor(
    private httpClient: HttpClient,
    private route: ActivatedRoute,
    private router: Router
  ) {

    //initialize model
    this.clientRevenue = {
      clientName: '',
      jobNumber: 0,
      month: 1,
      projectName: '',
      netRevenue: 0,
      status: 1
    } as IClientRevenue;

    //get drop down data
    this.httpClient.get<INumberKeyValue[]>('/api/data/getmonths').subscribe(result => {

      this.months = result;

    }, error => console.log(error));

    this.httpClient.get<INumberKeyValue[]>('/api/data/getstatuses').subscribe(result => {

      this.statuses = result;

    }, error => console.log(error));

  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];

    if (this.id) {
      this.httpClient.get<IClientRevenue>('/api/clientrevenue/' + this.id).subscribe(result => {
        this.clientRevenue = result;
      });
    }
  }

  onSubmit(): void {

    if (this.clientRevenue
      && this.clientRevenue.id) {

      this.httpClient.put<boolean>('/api/clientrevenue/' + this.id, this.clientRevenue)
        .subscribe(() => {
            this.router.navigate(['/client-index'])
          
        }, error => this.errorMessage = error.error);
    }
    else if (this.clientRevenue) {
      this.httpClient.post<boolean>('/api/clientrevenue', this.clientRevenue)
        .subscribe(() => {
            this.router.navigate(['/client-index'])
        }, error => this.errorMessage = error.error);
    }
  }

  deleteClient(): void {
    this.httpClient.delete<boolean>('/api/clientrevenue/' + this.clientRevenue.id).subscribe(result => {
      this.router.navigate(['/client-index'])
    });
  }

}

export interface INumberKeyValue {
  key: string;
  value: number;
}

interface IClientRevenue {
  id: number;
  clientName: string;
  projectName: string;
  jobNumber: number;
  month: number;
  status: number;
  netRevenue: number;
}
