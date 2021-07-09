"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ClientAuditComponent = void 0;
var ClientAuditComponent = /** @class */ (function () {
    function ClientAuditComponent(httpClient, route) {
        this.httpClient = httpClient;
        this.route = route;
        this.clientAudits = [];
    }
    ClientAuditComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.id = this.route.snapshot.params['id'];
        if (this.id) {
            this.httpClient.get('/api/clientrevenue/getclientaudits/' + this.id).subscribe(function (result) {
                _this.clientAudits = result;
            });
        }
    };
    return ClientAuditComponent;
}());
exports.ClientAuditComponent = ClientAuditComponent;
//# sourceMappingURL=client-audit.component.js.map