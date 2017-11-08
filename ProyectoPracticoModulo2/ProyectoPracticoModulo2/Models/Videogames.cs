namespace ProyectoPracticoModulo2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public partial class Videogames
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string publisher { get; set; }

        public int year { get; set; }

        public int genre { get; set; }

        public Genre Genre()
        {
            return (Genre)this.genre;
        }

        public int platform { get; set; }

        public Platform Platform()
        {
            return (Platform)this.platform;
        }

        public int score { get; set; }

        public bool online { get; set; }

        public String Online()
        {
            return (online) ? "Yes" : "No";
        }

        public int pegi { get; set; }

        public PEGI Pegi()
        {
            return (PEGI)this.pegi;
        }



        public static List<Videogames> Listar()
        {
            List<Videogames> listaJuegos = new List<Videogames>();

            try
            {
                GameContext context = new GameContext();
                listaJuegos = context.Videogames.ToList();
            }
            catch (Exception e)
            {
                throw;
            }
            return listaJuegos;
        }

        public static Videogames GetGame(int id)
        {
            Videogames producto = null;

            try
            {
                GameContext context = new GameContext();
                producto = context.Videogames.Where(x => x.id == id).SingleOrDefault();
            }
            catch (Exception e)
            {
                throw;
            }
            return producto;
        }

        public void Save()
        {
            try
            {
                GameContext context = new GameContext();
                if (this.id > 0)
                {
                    context.Entry(this).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    context.Entry(this).State = System.Data.Entity.EntityState.Added;
                }
                context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public void Eliminar()
        {
            try
            {
                GameContext context = new GameContext();
                context.Entry(this).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Videogames GameContainString(string search)
        {
            Videogames game = null;

            try
            {
                GameContext context = new GameContext();
                search = search.ToLower();
                string[] palabrasBuscar = search.Split(' ');
                foreach (string palabra in palabrasBuscar)
                {
                    game = context.Videogames.Where(x => x.name.ToLower().Contains(palabra)).SingleOrDefault();
                }

            }
            catch (Exception e)
            {
            }
            return game;
        }


    }
}
