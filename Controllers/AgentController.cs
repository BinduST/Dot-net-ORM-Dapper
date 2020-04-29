using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using dotnet_dapper.DTOs;
using dotnet_dapper.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace dotnet_dapper.Controllers
{
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AgentController> _logger;

        public AgentController(IConfiguration configuration, ILogger<AgentController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        // GET api/agent/all
        [HttpGet]
        [Route("api/[controller]/all")]
        public List<Agent> GetAll()
        {
            List<Agent> agents = new List<Agent>();
            using (var conn = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                agents = conn.Query<Agent>("SELECT * FROM agent").ToList();
            }
            return agents;
        }

        [HttpGet]
        [Route("api/[controller]/{agentId}")]
        public Agent Get(string agentId)
        {
            Guid agentCodeInGuid = Guid.Parse(agentId);
            Agent agent = new Agent();
            var sql = "SELECT * FROM agent WHERE agent_code = @agentCode";
            using (var conn = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                agent = conn.Query<Agent>(sql, new { agentCode = agentCodeInGuid }).FirstOrDefault();
            }
            return agent;
        }
    }
}
