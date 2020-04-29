using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnet_dapper.Entities
{
    public class Customer
    {
        [Key]
        public System.Guid cust_code { get; set; }
        public string cust_name { get; set; }
        public string cust_city { get; set; }
        public int working_area { get; set; }
        public string cust_country { get; set; }
        public int grade { get; set; }
        public int opening_amt { get; set; }
        public int receive_amt { get; set; }
        public int payment_amt { get; set; }
        public int outstanding_amt { get; set; }
        public string phone_no { get; set; }
        public System.Guid agent_code { get; set; }
    }
}