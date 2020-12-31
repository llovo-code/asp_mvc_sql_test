using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test_ASP_MVC.Models.ViewModels
{
    public class Pedido_Model
    {

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name ="Cod_pedido")]
        public string Cod_pedido { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Cliente")]
        public string Cliente { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Termino_Pago")]
        public string Termino_Pago { get; set ; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Total_Pedido")]
        public float Total_Pedido { get; set ; }
    }
}