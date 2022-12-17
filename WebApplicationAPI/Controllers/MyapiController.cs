using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using WebApplicationAPI.BL;

namespace WebApplicationAPI.Controllers
{
    public class MyapiController : ApiController
    {
        Operations crud = new Operations();

        [HttpGet]
        [Route("api/Myapi")]
        public IHttpActionResult hello()
        {
            return Ok("Hello Word");
        }


        [HttpPost]
        [Route("api/newbook/")]
        public IHttpActionResult newBook(int number, string name, string address)
        {
            return Ok(crud.newcontent(number, name, address));
        }

        [HttpPost]
        [Route("api/editcontant/")]
        public IHttpActionResult editcontant(int id, int newnumber, string name, string address)
        {
            return Ok(crud.editcontent(id, newnumber, name, address));
        }

        [HttpGet]
        [Route("api/contants/")]
        public IHttpActionResult contants()
        {
            return Ok(crud.FetchAll());
        }

        [HttpPost]
        [Route("api/removecontant/")]
        public IHttpActionResult removecontant(int number)
        {
            return Ok(crud.removecontent(number));
        }
    }
}
