using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ApiResponseModels
{
   
    public class record
    {
        public string id { get; set; }
        public object userid { get; set; }
        public string title { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
    }

    public class ComplaintAPi
    {
        public int status { get; set; }
        public List<record> data { get; set; }
    }

    public class UserAPi
    {
        public int status { get; set; }
        public User data { get; set; }
    }
   
}
