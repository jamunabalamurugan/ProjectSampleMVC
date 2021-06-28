using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL_Lakshya;
using BAL_Lakshya;

namespace Final_Lakshya.Controllers
{
    public class OnlineTestController : Controller
    {
        LakshyaBALClass Lak_Bal_Obj = new LakshyaBALClass();
        // GET: OnlineTest
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSubjects_Prog()
        {
            List<SubjectsClass> li_sub = new List<SubjectsClass>();
            var res = Lak_Bal_Obj.getSubjects();
            foreach(var item in res)
            {
                if (item.Sub_Category == "Programming")
                {
                    li_sub.Add(new SubjectsClass(item.Sub_Id, item.Sub_Name, item.Sub_Category));
                }
            }
           
            return PartialView(li_sub);
        }
        public ActionResult GetSubjects_Apt()
        {
            List<SubjectsClass> li_sub = new List<SubjectsClass>();
            var res = Lak_Bal_Obj.getSubjects();
            foreach (var item in res)
            {
                if (item.Sub_Category == "Aptitude")
                {
                    li_sub.Add(new SubjectsClass(item.Sub_Id, item.Sub_Name, item.Sub_Category));
                }
            }
            return PartialView(li_sub);
        }

        List<ViewModel> ls = new List<ViewModel>();
        ViewModel m = new ViewModel();

        public ActionResult TakeTest(string id)
        {

            //int count_user = Convert.ToInt32(Session["count_user"]);
            //Lak_Bal_Obj.getQuestions(count_user,id);

            var res_mcq = Lak_Bal_Obj.getMCQ(id);
            var res_fib = Lak_Bal_Obj.getFIB(id);
            var res_tf = Lak_Bal_Obj.getTF(id);

            var mcq_ques = res_mcq.OrderBy(x => Guid.NewGuid()).Take(7).ToList();
            var fib_ques = res_fib.OrderBy(x => Guid.NewGuid()).Take(5).ToList();
            var tf_ques = res_tf.OrderBy(x => Guid.NewGuid()).Take(3).ToList();

            List<Questions> li_ques = new List<Questions>();
            List<Mcq_Options> mcq_opt = new List<Mcq_Options>();

            foreach (var item in mcq_ques)//storing mcq ques/options
            {
                li_ques.Add(new Questions(item.MCQ_Id, item.MCQ_Ques, item.MCQ_Ans_Key, item.Sub_Id_MCQ));
                if (item.Op_E != null)
                {
                    mcq_opt.Add(new Mcq_Options(item.MCQ_Id, item.Op_A, item.Op_B, item.Op_C, item.Op_D, item.Op_E));
                }
                else if (item.Op_D != null)
                {
                    mcq_opt.Add(new Mcq_Options(item.MCQ_Id, item.Op_A, item.Op_B, item.Op_C, item.Op_D));
                }
                else
                {
                    mcq_opt.Add(new Mcq_Options(item.MCQ_Id, item.Op_A, item.Op_B, item.Op_C));
                }
            }
            foreach (var item in fib_ques)//storing fib ques
            {
                li_ques.Add(new Questions(item.FB_Id, item.FB_Ques, item.FB_Ans_Key, item.Sub_Id_FB));
            }
            foreach (var item in tf_ques)//storing tf ques
            {
                li_ques.Add(new Questions(item.TF_Id, item.TF_Ques, item.TF_Ans_Key, item.Sub_Id_TF));
            }
         

            m.Questions = li_ques;
            m.Mcq_Options = mcq_opt;
            ls.Add(m);
            Session["a"] = ls;
            return View();
        }

        public ActionResult Start_Test()
        {
            ls = (List<ViewModel>)Session["a"];
            return View(ls);
        }
        [HttpPost]
        public ActionResult Test_Report(FormCollection fc)
        {
            string x = "ques";
            int y = 1;
            string attempt = "attempt";
            string ques = "quest";
            string correc = "corr";
            ls = (List<ViewModel>)Session["a"];
            foreach (var item in ls)
            {
                foreach(var item1 in item.Questions)
                {
                    x = "ques";
                    attempt = "attempt";
                    ques = "quest";
                    correc = "corr";
                    x = x + y.ToString();
                    ques = ques + y.ToString();
                    attempt = attempt + y.ToString();
                    correc = correc + y.ToString();
                    Session[ques] = item1.ques;
                    Session[attempt] = fc[x];
                    Session[correc] = item1.ans_key;
                    y++;
                }
            }
            

            //Session["ques2"] = fc["ques2"];
            //Session["ques3"] = fc["ques3"];
            //Session["ques4"] = fc["ques4"];
            //Session["ques5"] = fc["ques5"];
            //Session["ques6"] = fc["ques6"];
            //Session["ques7"] = fc["ques7"];
            //Session["ques8"] = fc["ques8"];
            //Session["ques9"] = fc["ques9"];
            //Session["ques10"] = fc["ques10"];
            //Session["ques11"] = fc["ques11"];
            //Session["ques12"] = fc["ques12"];
            //Session["ques13"] = fc["ques13"];
            //Session["ques14"] = fc["ques14"];
            //Session["ques15"] = fc["ques15"];

            return View();
        }
    }
}