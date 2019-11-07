using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autenticacao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao.Controllers
{
    [Produces("application/json")]
    [Route("api/StatusJogo")]
    public class StatusJogoAPIController : Controller
    {

        [HttpGet(Name = "ObterJogo")]
        [Route("Obter")]
        public Tabuleiro ObterJogo()
        {
            Tabuleiro t = new Tabuleiro();
            return t;
        }


        [HttpPost (Name = "Resultado")]
        [Route("Resultado")]
        public int ObterResultado (Tabuleiro tabuleiro)
        {
            
            return tabuleiro.Vencedor();
        }
        [HttpPost(Name = "Jogar")]
        [Route("Jogar")]
        public Tabuleiro Jogar ([FromBody]Tabuleiro t, [FromQuery]int Jogador,[FromQuery] int pos)
        {
             t.Jogar(Jogador, pos);
            return t;
        }
    }
}