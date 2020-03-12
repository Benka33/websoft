using System;
using System.Collections.Generic ;
using System.Text.Json;

namespace webapp.Models
{
    public class Account
    {
        public int number { get; set; }
        public int balance { get; set; }
        public string label { get; set; }
        public int owner { get; set; }
        
        public override string ToString() =>
            JsonSerializer.Serialize<Account>(this);
    }
}
