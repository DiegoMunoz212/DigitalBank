
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CapaPresentacion.ServiceUsuarios;

namespace CapaPresentacion.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        ServiceUsuarios.Service1Client serviceUs = new ServiceUsuarios.Service1Client();
        public ActionResult Index()
        {
            return View(serviceUs.getSelectUs());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View(serviceUs.getSelectUsId(id));
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            List<SelectListItem> sexoList = new List<SelectListItem>() {
            new SelectListItem {
                Text = "MASCULINO", Value = "m"
            },
            new SelectListItem {
                    Text = "FEMENINO", Value = "f"
                },
            };
                ViewData["sexoList"] = sexoList;


            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]

        public ActionResult Create(UsuarioBE obj)
        {
           
            
            try
            {
                serviceUs.setInsertUs(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            List<SelectListItem> sexoList = new List<SelectListItem>() {
            new SelectListItem {
                Text = "MASCULINO", Value = "m"
            },
            new SelectListItem {
                    Text = "FEMENINO", Value = "f"
                },
            };
            ViewData["sexoList"] = sexoList;


            return View(serviceUs.getSelectUsId(id));
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UsuarioBE obj)
        {
            try
            {
                // TODO: Add update logic here
                serviceUs.setUpdateUs(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            UsuarioBE usuario = new UsuarioBE();
            usuario = serviceUs.getSelectUsId(id);
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,UsuarioBE obj)
        {
            try
            {
                // TODO: Add delete logic here
                obj.Us_id = id;
                serviceUs.setDeleteUs(obj);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
