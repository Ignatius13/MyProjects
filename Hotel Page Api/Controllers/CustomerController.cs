using Curdoperations.Models;
using Microsoft.Ajax.Utilities;
using put_task.irepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace Curdoperations.Controllers
{
    public class CustomerController : ApiController
    {
        public readonly CustomerInterface1 Cus;
        private CustomerController() { }
        public CustomerController(CustomerInterface1 cus)
        {
            this.Cus = cus;
        }
        [Route("api/Customer/GetAllCustomers")]
        [HttpGet] 
        public IHttpActionResult GetAllCustomers()
        {
            var res = Cus.GetAllcusDetails();
            if (res.Count == 0)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [Route("api/Customer/Deletedetails/{id}")]
        [HttpDelete]
        public IHttpActionResult Deletedetails(int id)
        {
            var data = Cus.Deletedetails(id);

            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }
        [Route("api/Customer/Update")]
        [HttpPost]
        public IHttpActionResult UpdateAllDetails(productClass id) 
        {
          if(!ModelState.IsValid) 
                return BadRequest("not a valid state");
            var ret = Cus.UpdateAllDetails(id);
            if (ret == null) 
            {
                return NotFound();
            }
            return Ok(ret);
                
        }

        [Route("api/Coustomer/insert")]
        [HttpPost]
        public HttpResponseMessage insert(productClass CustomerId)
        {
            var abc = Cus.insert(CustomerId);
            return Request.CreateResponse(HttpStatusCode.OK, abc);
        }

        [Route("api/Customer/bulkinsert")]

        [HttpPost]
        public HttpResponseMessage bulkinsert(List<Customer> em)
        {
            var abc = Cus.Bulkinsert(em);
            return Request.CreateResponse(HttpStatusCode.OK, abc);
        }



        [Route("api/Customer/GetById/{CustomerId}")]
        [HttpGet]
        public IHttpActionResult GetById(int CustomerId)
        {
            var abc = Cus.GetById(CustomerId);
            if (abc == null)
            {
                return NotFound();

            }
            return Ok(abc);
        }



    }


}



