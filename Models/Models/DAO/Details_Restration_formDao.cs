using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class Details_Registration_formDao
    {
         private DB_Relief db;


        public Details_Registration_formDao()
        {
            db = new DB_Relief();
        }
        public List<Details_registration> ListAll(int reliefId, string userId)
        {
            //return db.Registration_forms.ToList();
            return db.Details_registration.Where(x => x.ID_re == reliefId && x.Registration_form.ID_user == userId).ToList();
        }
    }
}
