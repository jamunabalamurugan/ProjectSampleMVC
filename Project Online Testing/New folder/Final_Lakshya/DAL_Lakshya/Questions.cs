using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL_Lakshya
{
    public class Questions
    {
        [Key]
        public string q_id { get; set; }
        public string ques { get; set; }
        public string ans_key { get; set; }
        public string sub_id { get; set; }

        public Questions(string q_id, string ques, string ans_key,string sub_id)
        {
            this.q_id = q_id;
            this.ques = ques;
            this.ans_key = ans_key;
            this.sub_id = sub_id;
        }
    }
}