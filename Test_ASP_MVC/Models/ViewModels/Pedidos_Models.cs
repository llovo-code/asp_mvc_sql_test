using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test_ASP_MVC.Models.ViewModels
{
    public class Pedidos_Models
    {
     

        public Pedido_Model Pedido { get ; set; }
        public List<DetallePedido> Detalle { get ; set ; }
    }
}