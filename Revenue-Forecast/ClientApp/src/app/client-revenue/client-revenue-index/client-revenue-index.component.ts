import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'client-revenue-index-component',
  templateUrl: './client-revenue-index.component.html'
})
export class ClientRevenueIndexComponent {
  public clients: IClientRevenueViewModel[];

  constructor(
    private httpClient: HttpClient
  ) {

    httpClient.get<IClientRevenueViewModel[]>('/api/clientrevenue/GetClients')
      .subscribe(result => {
        this.clients = result;
      }, error => console.error(error));
    
  }

  public deleteClient(client: IClientRevenueViewModel) {
    this.httpClient.delete<boolean>('/api/clientrevenue/' + client.id).subscribe(result => {
      if (result) {
        var indexToDelete = this.clients.indexOf(client);
        this.clients.splice(indexToDelete, 1);
      }
    });
  }
}

interface IClientRevenueViewModel {
  id: number;
  clientName: string;
  projectName: string;
  jobNumber: number;
  monthName: string;
  statusName: string;
  netRevenue: number;
}
