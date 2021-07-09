using Microsoft.AspNetCore.Mvc;
using Revenue_Forecast.Data.EntityModels;
using Revenue_Forecast.Models;
using Revenue_Forecast.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Revenue_Forecast.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientRevenueController : ControllerBase
    {
        private readonly IClientRevenueService _service;
        private readonly IClientRevenueAuditService _auditService;

        public ClientRevenueController(
            IClientRevenueService service,
            IClientRevenueAuditService auditService)
        {
            _service = service;
            _auditService = auditService;
        }

        [HttpGet("getClients")]
        public async Task<IEnumerable<ClientRevenueViewModel>> GetClients()
        {
            return await _service.GetClients();
        }

        [HttpGet("getMonthlyProjects")]
        public async Task<IEnumerable<ClientRevenueMonthlyModel>> GetMonthlyProjects(
            ProjectSearch? search, 
            string searchTerm
        )
        {
            return await _service.GetMonthlyProjects(search, searchTerm);
        }

        [HttpGet("getClientAudits/{id}")]
        public async Task<IEnumerable<ClientAuditViewModel>> GetClientAudits(
           int id
        )
        {
            return await _auditService.GetAudits(id);
        }

        [HttpGet("{id}")]
        public async Task<ClientRevenue> Get(int id)
        {
            return await _service.GetClient(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClientRevenue updatedClient)
        {
            var isUpdated = await _service.UpdateClient(id, updatedClient);

            if(!string.IsNullOrWhiteSpace(isUpdated))
            {
                return BadRequest(isUpdated);
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientRevenue client)
        {
            var isCreated = await _service.CreateClient(client);

            if (!string.IsNullOrWhiteSpace(isCreated))
            {
                return BadRequest(isCreated);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _service.DeleteClient(id);
        }
    }
}
