using Models.EF;
using PagedList;
using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.DAO
{
    public class Registration_formDao
    {
        private DB_Relief db;


        public Registration_formDao()
        {
            db = new DB_Relief();
        }

        public List<Registration_form> ListAll()
        {
            return db.Registration_forms.ToList();
        }
        
        public IEnumerable<Registration_form> LisWheretAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Registration_form> model = db.Registration_forms;
            
            return model.OrderBy(x => x.ID_relieft).ToPagedList(page, pagesize);
        }
        public Registration_form Find(string id)
        {
            return db.Registration_forms.Find(id);
        }

    }
}
