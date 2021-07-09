import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'client-audit-component',
  templateUrl: './client-audit.component.html'
})
export class ClientAuditComponent implements OnInit {

  clientAudits: IClientAuditViewModel[] = [];
  id: number;

  constructor(
    private httpClient: HttpClient,
    private route: ActivatedRoute
  ) {
  }

    ngOnInit(): void {
      this.id = this.route.snapshot.params['id'];

      if (this.id) {
        this.httpClient.get<IClientAuditViewModel[]>('/api/clientrevenue/getclientaudits/' + this.id).subscribe(result => {
          this.clientAudits = result;
        });
      }
  }

  hasAnyAudits(): boolean {
    return this.clientAudits
      && this.clientAudits.length > 0;
  }

}

interface IClientAuditViewModel {
  changeDateTime: string;
  oldValues: string;
  newValues: string;
}
