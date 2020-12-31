using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test_ASP_MVC.Models.ViewModels
{
    public class DetallePedido
    {

       
        [DisplayName("IdPedido")]
        [Required]
        public int IdPedido { get ; set ; }

        [DisplayName("Articulo")]
        [Required]
        public int Articulo { get  ; set; }

        [DisplayName("Cantidad")]
        [Required]
        public int Cantidad { get; set; }

        [DisplayName("Precio")]
        [Required]
        public float Precio{ get ;set ; }


        [DisplayName("SubTotal")]
        public float SubTotal { get; set; }
    }
}