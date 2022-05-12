using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniUti.Database;

namespace UniUti.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class InstituicaoController : ControllerBase
    {
        private readonly ApplicationDbContext _database;

        public InstituicaoController(ApplicationDbContext database)
        {
            _database = database;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("GET INSTITUICAO FUNCIONA.");
        }

        [HttpPost]
        public IActionResult Post(string nome)
        {
            return Ok($"Nome: {nome}");
        }
    }
}