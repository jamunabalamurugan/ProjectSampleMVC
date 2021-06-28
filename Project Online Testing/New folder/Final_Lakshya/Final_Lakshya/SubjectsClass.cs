using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final_Lakshya
{
    public class SubjectsClass
    {
        public string sub_id;
        public string sub_name;
        public string sub_cat;

        public SubjectsClass(string sub_id,string sub_name,string sub_cat)
        {
            this.sub_id = sub_id;
            this.sub_name = sub_name;
            this.sub_cat = sub_cat;

        }
    }
}