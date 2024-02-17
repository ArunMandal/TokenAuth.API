using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TokenAuth.API.Data
{
    public class ApplicationDbConnect:DbContext
    {
        public ApplicationDbConnect():base("DefaultConnection")
        {

        }


    }
}