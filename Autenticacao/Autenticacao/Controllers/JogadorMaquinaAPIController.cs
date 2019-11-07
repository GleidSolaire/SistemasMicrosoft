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
    [Route("api/JogadorMaquina")]
   
    public class JogadorMaquinaAPIController : Controller
    {
       
        
        [HttpPost(Name = "Calcular")]
        [Route("calcular")]
        public int CalcularJogada (Tabuleiro  tabuleiro)
        {
            JogadorComputador computador = new MaquinaFacil();
            return computador.CalcularJogada(tabuleiro);

        }
    }
}