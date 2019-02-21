using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SistemaLembretes.Models;

namespace SistemaLembretes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LembreteController : ControllerBase
    {
        private readonly LembreteDbContext context;

        public LembreteController(LembreteDbContext context)
        {
            this.context = context;
        }

        // GET api/getall
        [Route("~/api/GetAll")]
        [HttpGet]
        public ActionResult<IEnumerable<Lembrete>> Get()
        {
            var lembretes = context.Lembretes.ToList();
            return Ok(lembretes);
        }

        // GET api/find/5
        [Route("~/api/find/{id}")]
        [HttpGet("{id}")]
        public ActionResult<Lembrete> Get(int id)
        {
            var lembretes = context.Lembretes.Find(id);
            return Ok(lembretes);
        }

        // POST api/create
        [Route("~/api/create")]
        [HttpPost]
        public ActionResult Post([FromBody] Lembrete value)
        {
            context.Lembretes.Add(value);
            context.SaveChanges();
            return Ok(value);
        }
    }
}
