using System;
using System.Collections.Generic;
using System.Text;

namespace ContactoDesktop.Models
{
    public class ResponseModel<T>
    {
        public ResponseModel()
        {
            Records = new List<T>();
            Values = new List<dynamic>();
            OK=true;
            Errors = new List<string>();
            Message = new List<string>();
        }

        public List<T> Records { get; set; }
        public List<dynamic> Values { get; set; }
        public bool OK { get; set; }
        public List<string> Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
