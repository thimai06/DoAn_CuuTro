using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class Relief_classificationDao
    {
        private DB_Relief db;

        public Relief_classificationDao()
        {
            db = new DB_Relief();
        }
        public List<Relief_classification> ListAll()
        {
            return db.Relief_classification.ToList();
        }
        public IEnumerable<Relief_classification> LisWheretAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Relief_classification> model = db.Relief_classification;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Description.Contains(keysearch));
            }
            return model.OrderBy(x => x.Description).ToPagedList(page, pagesize);
        }
        public List<Relief_classification> ListWhereAll(String keysearch)
        {
            return db.Relief_classification.Where(x => x.Description.Contains(keysearch)).ToList();
        }
        public String Insert(Relief_classification enti_rc)
        {
            db.Relief_classification.Add(enti_rc);
            db.SaveChanges();
            return enti_rc.Description;
        }
        public Relief_classification Find(String id)
        {
            return db.Relief_classification.Find(id);
        }
    }
}
