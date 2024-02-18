using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TokenAuth.API.Data;
using TokenAuth.API.Models;

namespace TokenAuth.API.Controllers
{
    public class EmployeeController : ApiController
    {
        ApplicationDbConnect dbcontext = new ApplicationDbConnect();

        [Authorize(Roles =("User"))]
        public  HttpResponseMessage GetEmployee(int id)
        {
            var user = dbcontext.Employees.FirstOrDefault(e => e.Id == id);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Authorize(Roles = ("Admin, SuperAdmin"))]
        [Route("api/Employee/GetSomeEmployee")]
        public HttpResponseMessage GetSomeEmployee()
        {
            var user = dbcontext.Employees.FirstOrDefault(e => e.Id <=10);
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Authorize(Roles = ("SuperAdmin"))]
        [Route("api/Employee/GetAllEmployee")]
        public HttpResponseMessage GetAllEmployee()
        {
            var user = dbcontext.Employees.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }
    }
}
