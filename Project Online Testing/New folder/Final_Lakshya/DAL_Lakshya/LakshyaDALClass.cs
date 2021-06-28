using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Lakshya
{
    public class LakshyaDALClass
    {
        db_Lakshay_OnlinetestEntities db_lakshya = new db_Lakshay_OnlinetestEntities();

        public IEnumerable<tbl_User> User_Activate()
        {
            List<tbl_User> user_act = db_lakshya.tbl_User.ToList();

            var res = from i in user_act
                      where i.Mail_Status==false
                      select i;

            return res;

        }


        public IEnumerable<tbl_User> SendMail(string id)
        {
            List<tbl_User> sendmail = db_lakshya.tbl_User.ToList();

            var res = from i in sendmail
                      where i.User_Id == id
                      select i;

            return res;

        }

        public bool Mail_Status_Update(string id)
        {
            List<tbl_User> update_status = db_lakshya.tbl_User.ToList();
            (from i in update_status
                       where i.User_Id == id
                       select i).ToList()
                                .ForEach(x => x.Mail_Status = true);
            db_lakshya.SaveChanges();
            return true;
        }

        public bool User_Register(tbl_User u)
        {
            db_lakshya.tbl_User.Add(u);
            db_lakshya.SaveChanges();
            return true;
        }

        public IEnumerable<tbl_User> User_Login()
        {
            List<tbl_User> user = db_lakshya.tbl_User.ToList();

            //var User_Id = user.Select(x => x.User_Id);
            //var pass = user.Select(x => x.Password);
            //var mail_status = user.Select(x => x.Mail_Status);

            var res = from i in user
                      select i;

            return res;
            
        }

        public IEnumerable<tbl_Subjects> getSubject()
        {
            List<tbl_Subjects> subjects = db_lakshya.tbl_Subjects.ToList();
            var res = from i in subjects
                      select i;
            return res;
        }

        public IEnumerable<tbl_MCQ> getMCQ(string id)
        {
            List<tbl_MCQ> MCQ = db_lakshya.tbl_MCQ.ToList();
            var res = from i in MCQ
                      where i.Sub_Id_MCQ == id
                      select i;
            return res;
        }

        public IEnumerable<tbl_FillBlank> getFIB(string id)
        {
            List<tbl_FillBlank> FB = db_lakshya.tbl_FillBlank.ToList();
            var res = from i in FB
                      where i.Sub_Id_FB == id
                      select i;
            return res;
        }

        public IEnumerable<tbl_TrueOrFalse> getTF(string id)
        {
            List<tbl_TrueOrFalse> TF = db_lakshya.tbl_TrueOrFalse.ToList();
            var res = from i in TF
                      where i.Sub_Id_TF == id
                      select i;
            return res;
        }

        //public void getQuestions(int user_count,string id)
        //{
        //    List<tbl_MCQ> mcq = db_lakshya.tbl_MCQ.ToList();
        //    List<tbl_FillBlank> fib = db_lakshya.tbl_FillBlank.ToList();
        //    List<tbl_TrueOrFalse> tf = db_lakshya.tbl_TrueOrFalse.ToList();

        //    var mcq_ques = mcq.OrderBy(x => Guid.NewGuid()).Take(8).ToList();
        //    var fib_ques = fib.OrderBy(x => Guid.NewGuid()).Take(4).ToList();
        //    var tf_ques = tf.OrderBy(x => Guid.NewGuid()).Take(3).ToList();

        //    int x = (30 % user_count)+1;

        //    var res_test_MCQ = from i in mcq
        //                       where i.Sub_Id_MCQ == id
        //                       select i;

        //    var res_test_FB = from i in fib
        //                      where i.Sub_Id_FB == id
        //                      select i;

        //    var res_test_TF = from i in tf
        //                      where i.Sub_Id_TF == id
        //                      select i;



        //    List<tbl_Test> test = db_lakshya.tbl_Test.ToList();
        //    var res_test= from i in test
        //                  where i.Sub_Id_Test == id
        //                  select i;

        //    int count_ques = 0;
        //    int ctr = 0;
        //    foreach (var item1 in res_test)
        //    {
        //        count_ques = Convert.ToInt32(item1.No_of_Ques);
        //    }

        //    int ques_item_id=0;
        //    string ques_id=null;

        //    List < Questions > li_ques = new List<Questions>();
        //    List<Mcq_Options> mcq_opt = new List<Mcq_Options>();

        //    foreach (var item in res_test_MCQ)//storing mcq ques/options
        //    {
        //        ques_id = item.MCQ_Id;
        //        ques_item_id = Convert.ToInt32(ques_id.Substring(ques_id.Length - 1));


        //        li_ques.Add(new Questions(item.MCQ_Id, item.MCQ_Ques, item.MCQ_Ans_Key,item.Sub_Id_MCQ));
        //        if (item.Op_E!=null)
        //        {
        //            mcq_opt.Add(new Mcq_Options(item.MCQ_Id, item.Op_A, item.Op_B, item.Op_C, item.Op_D, item.Op_E));
        //        }
        //        else if (item.Op_D!=null)
        //        {
        //            mcq_opt.Add(new Mcq_Options(item.MCQ_Id, item.Op_A, item.Op_B, item.Op_C, item.Op_D));
        //        }
        //        else
        //        {
        //            mcq_opt.Add(new Mcq_Options(item.MCQ_Id, item.Op_A, item.Op_B, item.Op_C));
        //        }
        //    }
        //    foreach (var item in res_test_FB)//storing fib ques
        //    {
        //        li_ques.Add(new Questions(item.FB_Id, item.FB_Ques, item.FB_Ans_Key,item.Sub_Id_FB));
        //    }
        //    foreach (var item in res_test_TF)//storing tf ques
        //    {
        //        li_ques.Add(new Questions(item.TF_Id, item.TF_Ques, item.TF_Ans_Key,item.Sub_Id_TF));
        //    }
        //    List<ViewModel> ls = new List<ViewModel>();
        //    ViewModel m = new ViewModel();

        //    m.Questions = li_ques;
        //    m.Mcq_Options = mcq_opt;
        //    ls.Add(m);
        //    Session["a"] = ls;



        //}



    }
}
