using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test_ASP_MVC.Models;
using Test_ASP_MVC.Models.ViewModels;

namespace Test_ASP_MVC.Controllers
{
    public class ArticulosController : Controller
    {
        // GET: Articulos
        public ActionResult All_Article()
        {

            List<Articulos_Model> lst;
            using (DatabaseEntities db = new DatabaseEntities())
            {
                lst = (from d in db.ListarArticulos()
                       select new Articulos_Model
                       {
                           IdArticulo = d.ID,
                           Codigo_Articulo = d.Codigo_Articulo,
                           Descripicon = d.Descripcion,
                           Cod_categoria = d.Codigo_Categoria,
                           Nombre_categoria = d.Nombre_Categoria,
                           Precio = (float)d.Precio
                       }).ToList();
            }

                return View(lst);
        }

        public ActionResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddArticle(Articulos_Model model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(DatabaseEntities db = new DatabaseEntities())
                    {

                        db.AddArticulo(model.Codigo_Articulo,model.Descripicon,model.Cod_categoria,model.Precio);
                        db.SaveChanges();

                      return Redirect("~/");


                    }
                }

                return  View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
    }
}