using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerViVuTraVinh.Helpers
{
    public class JsonResponse<T>
    {
        public bool Error
        {
            get;
            set;
        }
        public string Message
        {
            get;
            set;
        }
        public T Data
        {
            get;
            set;
        }
        public int StatusCode
        {
            get;
            set;
        } 
    }
}