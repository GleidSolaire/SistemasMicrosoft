using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioRotas.Controllers
{
    public class OPController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dobrar(int Id)
        {
            ViewData["Resultado"] = "->" + Id * 2;

            return View();
        }
        
        //public IActionResult Somar (int Id, int parametrob)
        //{
        //    ViewData["Resultado"] =  + Id + parametrob;

        //    return View();
        //}
        public IActionResult Somar(int a, int b, int c)
        {
            ViewData["Resultado"] = a + b + c;

            return View();
        }

        public IActionResult Subtrair(int Id, int parametrob)
        {
            ViewData["Resultado"] = +Id - parametrob;

            return View();
        }
       

    }
}