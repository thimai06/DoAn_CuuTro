using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class Details_ReceiptDao
    {
        private DB_Relief db;


        public Details_ReceiptDao()
        {
            db = new DB_Relief();
        }
        //public List<Details_Receipt> ListAll(int reliefId, string userId)nghe 
        //{
        //    //return db.Registration_forms.ToList();
        //    return db.Details_registration.Where(x => x.ID_re == reliefId && x.Registration_form.ID_user == userId).ToList();
        //}
    }
}
