using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreApiExamples.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreApiExamples.Controllers
{
    [Route("api/[controller]")]
    public class ContentController : Controller
    {
        
        [HttpGet("string")]
        public string GetString() => "This is a string response";

        #region 1
        //[HttpGet("object")]
        //[Produces("application/json")] 
        #endregion
        #region 2
        //[HttpGet("object/{format?}")]
        //[FormatFilter]
        //[Produces("application/json", "application/xml")] 
        #endregion

        [HttpGet("object/{format?}")]
        [FormatFilter]
        public Reservation GetObject() => new Reservation
        {
            ReservationId = 100,
            ClientName = "Joe",
            Location = "Board Room"
        };

        //返回的内容格式受以下几个因素影响
        //1 客户端接受什么格式
        //2 MVC采用什么格式
        //3 action返回什么格式
        
        //背后的原理是响应表头有一个Content-Type属性，可以设置成text/plain,也可以设置成application/json
        
        //客户端，比如谷歌浏览器：Accept:text/html,applicaiton/xhtl+xml, applicaiton/xml;q=0.9;image/webp,*/*;q=0.8

        //Produce是服务端返回什么格式
        //Consume是服务端接受什么格式


        [HttpPost]
        [Consumes("application/json")]
        public Reservation ReceiveJson([FromBody]Reservation reservation)
        {
            reservation.ClientName = "json";
            return reservation;
        }

        [HttpPost]
        [Consumes("application/xml")]
        public Reservation ReceiveXml([FromBody] Reservation reservation)
        {
            reservation.ClientName = "xml";
            return reservation;
        }
    }
}
