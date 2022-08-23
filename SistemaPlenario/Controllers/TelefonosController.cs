using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaPlenario.Models;

namespace SistemaPlenario.Controllers
{
    public class TelefonosController : Controller
    {
        public ActionResult Index()
        {
            List<Telefonos> lista = null;
            SPlenarioEntities1 d = new SPlenarioEntities1();
                lista = (from db in d.Telefonos
                         select db).ToList();
            return View(lista);
        }

        public ActionResult Alta()
        {
            //Genero el listado de Personas para mostrarse en el DropDownListFor
            List<Personas> personas = null;
            using(SPlenarioEntities1 db=new SPlenarioEntities1())
            {
                personas = (from d in db.Personas
                            select d).ToList();
            }
            List<SelectListItem> items = personas.ConvertAll(d =>
              {
                  return new SelectListItem()
                  {
                      Text = d.Nombre,
                      Value = d.PersonaID.ToString(),
                      Selected = false

                  };
              });
            ViewBag.items = items;
            return View();
        }
        [HttpPost]
        public ActionResult Alta(Telefonos model)
        {
            using (var d = new SPlenarioEntities1())
            {
                d.Telefonos.Add(model);
                d.SaveChanges();
            }
            return RedirectToAction("Alta");
        }
        
        public ActionResult Eliminar(int iD)
        {
            using (SPlenarioEntities1 db = new SPlenarioEntities1())
            {
                Telefonos telefono = db.Telefonos.Find(iD);
                db.Telefonos.Remove(telefono);
                db.Entry(telefono).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            return Content("1");
        }

        public ActionResult Editar(int iD)
        {
            Telefonos telefono = null;
            using(SPlenarioEntities1 db = new SPlenarioEntities1())
            {
                telefono = db.Telefonos.Find(iD);
            }
            List<Personas> personas = null;
            using (SPlenarioEntities1 db = new SPlenarioEntities1())
            {
                personas = (from d in db.Personas
                            select d).ToList();
            }
            List<SelectListItem> items = personas.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre,
                    Value = d.PersonaID.ToString(),
                    Selected = false

                };
            });
            ViewBag.items = items;
            return View(telefono);
        }

        [HttpPost]
        public ActionResult Editar(Telefonos model)
        {
            using(SPlenarioEntities1 d = new SPlenarioEntities1())
            {
                Telefonos oTelefono = d.Telefonos.Find(model.TelefonoID);
                oTelefono.Telefono = model.Telefono;
                oTelefono.Personas = model.Personas;
                oTelefono.PersonaID = model.PersonaID;

                d.Entry(oTelefono).State = System.Data.Entity.EntityState.Modified;
                d.SaveChanges();
            }
            return Redirect(Url.Content("~/Telefonos/Index"));
        }
    }
}

