using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;
using Test_ASP_MVC.Models.ViewModels;
using System.IO;


using static System.Net.Mime.MediaTypeNames;

namespace Test_ASP_MVC.Controllers
{
    public class PedidosController : Controller
    {
        // GET: Pedidos
        [HttpGet]
        public ActionResult Add_Pedido()
        {
            var cod = 0 ;
            var order = "";
            char zero = '0';
            JsonSerializer serializer = new JsonSerializer();
            string pathoutput = AppDomain.CurrentDomain.BaseDirectory + "dbjson\\data.json";
            if (new FileInfo(pathoutput).Length > 0)
            {
                //foreach (var pmodel in pd)
                //{
                //    order = pmodel.Pedido.Cod_pedido.ToString();

                //    if (Convert.ToInt32(order.TrimStart(zero)) > cod)
                //    {
                //        cod = Convert.ToInt32(order.TrimStart(zero));

                //    }
                //}
            }
            else
            {
                cod = 1;
                ViewData["Cod"] = cod;
            }
           
            return View();
        }


        [HttpPost]
        [ActionName("Add_pedido")]
        [WebMethod]
        // [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public ActionResult Add_Pedido(List<DetallePedido> detalle, Pedido_Model pedido)
        {

            Pedidos_Models pd = new Pedidos_Models()
            {
                Pedido = pedido,
                Detalle = detalle
            };

            List<Pedidos_Models> Lp = new List<Pedidos_Models>();
            Lp.Add(pd);
           // JsonSerializer serializer = new JsonSerializer();
            string outputjson = JsonConvert.SerializeObject(Lp);
            string Namefile = "data.json";
            string pathoutput = AppDomain.CurrentDomain.BaseDirectory +"dbjson";

            if (Directory.Exists(pathoutput))
            {
                Environment.CurrentDirectory = pathoutput;
                if (System.IO.File.Exists(Namefile))
                {
                    System.IO.File.AppendAllText(Path.Combine(pathoutput, Namefile), outputjson);

                }
                else
                {
                    System.IO.File.Create(pathoutput + Namefile);
                    System.IO.File.WriteAllText(Path.Combine(pathoutput, Namefile), outputjson);

                }
            }
            else
            {
                System.IO.Directory.CreateDirectory(pathoutput);
                Environment.CurrentDirectory = pathoutput;
                System.IO.File.AppendAllText(Path.Combine(pathoutput, Namefile), outputjson);
            }
            return Json(new { Result="OK"});
        }


        public ActionResult ShowPedidos()
        {
            JsonSerializer serializer = new JsonSerializer();
            string filename = "dbjsondata.json";
            string pathoutput = AppDomain.CurrentDomain.BaseDirectory ;
            string json = System.IO.File.ReadAllText(Path.Combine(pathoutput, filename));

            List < Pedido_Model > lstpd = JsonConvert.DeserializeObject<List<Pedido_Model>>(json);
            lstpd = lstpd.OrderBy(d => Convert.ToInt32(d.Cod_pedido)).ToList();
            return View(lstpd);
        }

    }
}