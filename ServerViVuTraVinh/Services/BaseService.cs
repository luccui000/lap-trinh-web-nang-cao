using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerViVuTraVinh.Services
{
    public class BaseService: System.Web.Services.WebService
    {
        protected DBViVuTraVinhDataContext db = new DBViVuTraVinhDataContext();
    }
}