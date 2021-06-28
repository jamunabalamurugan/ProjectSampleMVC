using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Lakshya
{
    public class Mcq_Options
    {
        [Key]
        public string q_id { get; set; }
        public string Op_A { get; set; }
        public string Op_B { get; set; }
        public string Op_C { get; set; }
        public string Op_D { get; set; }
        public string Op_E { get; set; }

        public Mcq_Options()
        {
            q_id = null;
            Op_A = null;
            Op_B = null;
            Op_C = null;
            Op_D = null;
            Op_E = null;
        }

        public Mcq_Options(string q_id, string a, string b, string c, string d, string e)
        {
            this.q_id = q_id;
            Op_A = a;
            Op_B = b;
            Op_C = c;
            Op_D = d;
            Op_E = e;
        }

        public Mcq_Options(string q_id, string a, string b, string c, string d)
        {
            this.q_id = q_id;
            Op_A = a;
            Op_B = b;
            Op_C = c;
            Op_D = d;
        }

        public Mcq_Options(string q_id, string a, string b, string c)
        {
            this.q_id = q_id;
            Op_A = a;
            Op_B = b;
            Op_C = c;
        }
    }
}