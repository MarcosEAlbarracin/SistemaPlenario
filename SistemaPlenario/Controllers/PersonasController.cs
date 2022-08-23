using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaPlenario.Models;

namespace SistemaPlenario.Controllers
{
    public class PersonasController : Controller
    {
        public ActionResult Index()
        {
            List<Personas> personas = null;
            using (SPlenarioEntities1 d = new SPlenarioEntities1())
            {
                personas = (from p in d.Personas
                           select p).ToList();
            }

            return View(personas);
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(Personas persona)
        {
                 using (var d= new SPlenarioEntities1())
                 {
                     d.Personas.Add(persona);
                     d.SaveChanges();
                 }
                 return RedirectToAction("Crear");

            
        }
        
        public ActionResult Editar(int id)
        {
            Personas persona = new Personas();
            using(SPlenarioEntities1 db = new SPlenarioEntities1())
            {
                persona = db.Personas.Find(id);
            }

            return View(persona);
        }

        public ActionResult Eliminar(int id)
        {
            SPlenarioEntities1 d = new SPlenarioEntities1();
            Personas persona = d.Personas.Find(id);
            d.Personas.Remove(persona);
            //Crear un listado de los telefonos de la persona para borrarlos tambien.
            //Sin Persona no debe haber registro de Telefonos.
            List<Telefonos> telefono = null;
            telefono = (from lst in d.Telefonos
                       where lst.PersonaID == id
                       select lst).ToList();

            if (telefono.Count!= 0)
            {
                foreach (var tel in telefono) { 
                    d.Telefonos.Remove(tel);
                    d.Entry(tel).State = System.Data.Entity.EntityState.Deleted;
                }
            }
            d.Entry(persona).State = System.Data.Entity.EntityState.Deleted;
            d.SaveChanges();
            //return Redirect(Url.Content("~/Personas/Index"));
            return Content("1");
        }

        [HttpPost]
        public ActionResult Editar(Personas persona)
        {
            using(SPlenarioEntities1 db=new SPlenarioEntities1())
            {
                var oPersona = db.Personas.Find(persona.PersonaID);
                oPersona.Nombre = persona.Nombre;
                oPersona.FechaNacimiento = persona.FechaNacimiento;
                oPersona.CreditoMaximo = persona.CreditoMaximo;

                db.Entry(oPersona).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Personas/Index"));
        }
    }
}