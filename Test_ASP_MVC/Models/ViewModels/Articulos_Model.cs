using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_ASP_MVC.Models.ViewModels
{
    public class Articulos_Model
    {
        private int idArticulo;
        private string codigo_Articulo;
        private string descripicon;
        private string cod_categoria;
        private string nombre_categoria;
        private float precio;

        public int IdArticulo { get => idArticulo; set => idArticulo = value; }
        public string Codigo_Articulo { get => codigo_Articulo; set => codigo_Articulo = value; }
        public string Descripicon { get => descripicon; set => descripicon = value; }
        public float Precio { get => precio; set => precio = value; }
        public string Cod_categoria { get => cod_categoria; set => cod_categoria = value; }
        public string Nombre_categoria { get => nombre_categoria; set => nombre_categoria = value; }
    }
}