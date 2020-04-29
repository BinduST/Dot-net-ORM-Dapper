using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnet_dapper.Entities
{
    public class Agent
    {
        [Key]
        public System.Guid agent_code { get; set; }
        public string agent_name { get; set; }
        public string working_area { get; set; }
        public int commission { get; set; }
        public int phone_no { get; set; }
        public string country { get; set; }
    }
}