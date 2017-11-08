using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoPracticoModulo2.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            List<Models.Videogames> games = Models.Videogames.Listar().OrderBy(x => x.name).ToList();
            return View(games);
        }

        public ActionResult Ver(int id)
        {
            if (id != 0)
            {
                Models.Videogames game = Models.Videogames.GetGame(id);
                if (game != null)
                {
                    return View(game);
                }
                else
                {
                    return Redirect("~/");
                }
            }
            else
            {
                return Redirect("~/");
            }
        }

        public ActionResult Crear()
        {
            Models.Videogames game = new Models.Videogames();
            return View("gameForm", game);
        }

        public ActionResult Guardar(Models.Videogames videogames)
        {
            videogames.Save();
            return Redirect("~/Home/ver/" + videogames.id);
        }
        

        public ActionResult Editar(int id=0)
        {
            if (id != 0)
            {
                Models.Videogames game = Models.Videogames.GetGame(id);
                return View("gameForm", game);
            }
            else
            {
                return Redirect("~/");
            }
        }

        public ActionResult Eliminar(int id = 0)
        {
            Models.Videogames videogames = Models.Videogames.GetGame(id);
            videogames.Eliminar();
            return Redirect("~/");
        }

        public ActionResult Ranking()
        {
            List<Models.Videogames> games = Models.Videogames.Listar().OrderByDescending(x => x.score).ToList();
            return View(games);
        }

        public ActionResult SearchGame()
        {
            string search =Request.Form["search"];
            Models.Videogames game = null;
            if (search != null)
            {
                game = Models.Videogames.GameContainString(search);
            }
            return View(game);
        }


    }
}
