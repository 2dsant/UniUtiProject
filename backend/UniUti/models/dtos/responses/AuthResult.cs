using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniUti.models;

namespace UniUti.Configuration
{
    public class AuthResult
    {
        public string Token { get; set; }
        public Usuario Usuario { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}