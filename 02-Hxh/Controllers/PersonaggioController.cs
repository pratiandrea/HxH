using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _02_Hxh.Model;
using _02_Hxh.Services;

namespace _02_Hxh.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonaggioController : ControllerBase
    {
        private IPersonaggioService _personaggioService = PersonaggioService.GetInstance();

        [HttpGet]
        public IEnumerable<Personaggio> Get() 
        {
            var res = _personaggioService.GetAll();

            return res;
        } 

        [HttpPost]
        public void AddNewPersonaggio([FromBody] Personaggio p) 
        {
            _personaggioService.AddPersonaggio(p);
        }

        [HttpGet("{id}")]
        public Personaggio GetById([FromRoute] int id)
        {
            return _personaggioService.GetById(id);
        }

        [HttpPut("{id}")]
        public void UpdatePerson([FromRoute] int id, [FromBody] Personaggio p)
        {
            p.Id = id;
            _personaggioService.UpdatePersonaggio(p);
        }

        [HttpDelete("{id}")]
        public void RemoveById([FromRoute] int id)
        {
            _personaggioService.DeletePersonaggio(id);
        }
    }
}
