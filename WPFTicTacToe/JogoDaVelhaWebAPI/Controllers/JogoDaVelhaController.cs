using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JogoDaVelha;

namespace JogoDaVelhaWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/JogoDaVelha")]
    public class JogoDaVelhaController : Controller
    {
        
        /// <summary>
        /// Váriavel estática para representar o jogo da velha. 
        /// Está é uma solução simples e didática para demonstrar a utilização
        /// de API Rest. A utilização de variáves estáticas é algo a ser 
        /// evitado.
        /// </summary>
        static TabuleiroJogo Jogo { get; set; }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="jogador">O jogador realizando a jogada.</param>
        /// <param name="posX">A coluna.</param>
        /// <param name="posY">A fileira.</param>
        /// <returns></returns>
        [HttpGet("{jogador}/{posX}/{posY}")]
        public String Jogar(int jogador, int posX, int posY)
        {
            Jogo.Jogar(jogador, posX, posY);
            switch (Jogo.Ganhador)
            {
                case 0:
                    return "Jogo em andamento";
                case -1:
                    return "Jogo terminou empatado.";
                case 1:
                    return "Jogador 1 venceu.";
                case 2:
                    return "Jogador 2 venceu.";
            }
            return "";
        }

        /// <summary>
        /// Recomeça o jogo.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Reset")]
        public String Reiniciar()
        {
            Jogo = new TabuleiroJogo();
            return "Jogo Reiniciado";
        }

        /// <summary>
        /// Obtem o objeto Tabuleiro. Ele será serializado no formato JSON.
        /// É possível saber o formato pela anotação "Produces" no nome da classe.
        /// </summary>
        /// <returns>Retorna o Tabuleiro.</returns>
        [HttpGet()]
        public TabuleiroJogo Get()
        {
            return Jogo;
        }

    }
}