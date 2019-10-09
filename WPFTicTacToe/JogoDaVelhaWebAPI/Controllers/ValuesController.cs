using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JogoDaVelhaWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {


        static List<int> valores = 
            new List<int>(new int[]{10, 100, 20,
                15, 40, 30, 11});

        // GET api/values
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return valores;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var resultado = valores.Where(v => v == id).ToList();
            return resultado.Count() ==0?
                "Não existe este valor" 
                : resultado.FirstOrDefault().ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var resultado = valores.Where(v => v == int.Parse(value)).ToList();
            if (resultado.Count() == 0)
            {
                valores.Add(int.Parse(value));
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            if(id>=0 && id < valores.Count())
            {
                valores[id] = int.Parse(value);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var resultado = valores.Where(v => v == id).ToList();
            if (resultado.Count() != 0)
            {
                foreach (var item in resultado)
                    valores.Remove(item);
            }
        }
    }
}
