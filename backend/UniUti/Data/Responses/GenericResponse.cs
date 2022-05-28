using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniUti.Data.Responses
{
    public class GenericResponse
    {
        public bool Success { get; set; }
        public List<string>? Messages { get; set; }
    }
}