using Curdoperations.irespo;
using Curdoperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Curdoperations.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class HomeController : ApiController
    {
        public readonly IReservation abc;
        public HomeController() { }
        public HomeController(IReservation ires)
        {
            abc= ires;
        }

        [Route("api/Home/GetAllDetails")]
        [HttpGet]
        public IHttpActionResult GetAllDetails()
        {
            var xyz = abc.GetAllDetails();
            if (xyz == null)
            {
                return NotFound();

            }
            return Ok(xyz);
            
        }

        [Route("api/Home/insert")]
        [HttpPost]
        public HttpResponseMessage insert(resModel em) 
        {
            var xyz = abc.insert(em);
            return Request.CreateResponse(HttpStatusCode.OK, xyz);
        }

        
        [Route("api/Home/delete/{ReservationId}")]
        [HttpDelete]
        public  string Delete1(int ReservationId)

        { 
            return abc.delete(ReservationId);
        }


        [Route("api/Home/update")]
        [HttpPost]
        public IHttpActionResult Update(resModel em)
        {
            var x = abc.update(em);
            if (x == null)
            {
                return NotFound();
            }
            return Ok("Updated");
        }

        [Route("api/Home/test")]
        [HttpGet]
        public HttpResponseMessage test() 
        {
            var b = abc.sp_getall();
            return Request.CreateResponse(HttpStatusCode.OK,b);

        }
        //[Route("api/Home/SPinsert")]
        //[HttpPost]
        //public HttpResponseMessage insert(SP_Getall_Result res)
        //{
        //    var xyz = abc.sp_insert(res);
        //    return Request.CreateResponse(HttpStatusCode.OK, xyz);
        //}



    }
}
