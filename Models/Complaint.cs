using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
  public  class Complaint
    {

        public string id { get; set; }
        public string userid { get; set; }

        public string title { get; set; }
        public string Mobile { get; set; }

        public string Email { get; set; }
        public string description { get; set; }

        public DateTime Date { get; set; }


    }
}
