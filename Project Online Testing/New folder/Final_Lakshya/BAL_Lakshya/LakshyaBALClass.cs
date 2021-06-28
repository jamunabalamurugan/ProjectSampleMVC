using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Lakshya;

namespace BAL_Lakshya 
{
    public class LakshyaBALClass
    {
        LakshyaDALClass Lak_Dal_obj = new LakshyaDALClass();

        public IEnumerable<tbl_User> User_Activate()
        {
            var res = Lak_Dal_obj.User_Activate();
            return res;
        }


        public IEnumerable<tbl_User> SendMail(string id)
        {
            var res = Lak_Dal_obj.SendMail(id);

            return res;

        }
        public bool Mail_Status_Update(string id)
        {
            if (Lak_Dal_obj.Mail_Status_Update(id))
                return true;
            else
                return false;
        }
        public bool User_Register(tbl_User u)
        {

            if(Lak_Dal_obj.User_Register(u))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<tbl_User> User_Login()
        {
            var res = Lak_Dal_obj.User_Login();
            return res;
        }       
        
        public IEnumerable<tbl_Subjects> getSubjects()
        {
            var res = Lak_Dal_obj.getSubject();
            return res;

        }

        //public void getQuestions(int count_user,String id)
        //{
        //    Lak_Dal_obj.getQuestions(count_user,id);
        //}

        public IEnumerable<tbl_MCQ> getMCQ(string id)
        {

            var res = Lak_Dal_obj.getMCQ(id);
            return res;
        }

        public IEnumerable<tbl_FillBlank> getFIB(string id)
        {

            var res = Lak_Dal_obj.getFIB(id);
            return res;
        }

        public IEnumerable<tbl_TrueOrFalse> getTF(string id)
        {

            var res = Lak_Dal_obj.getTF(id);
            return res;
        }


    }
}
