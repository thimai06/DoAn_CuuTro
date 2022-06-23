using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class CategorizeDao
    {
        private DB_Relief db;

        public CategorizeDao()
        {
            db = new DB_Relief();
        }
        public List<categorize> ListAll()
        {
            return db.categorizes.ToList();
        }
        public IEnumerable<categorize> LisWheretAll(string keysearch, int page, int pagesize)
        {
            IQueryable<categorize> model = db.categorizes;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Name_cate.Contains(keysearch));
            }
            return model.OrderBy(x => x.Name_cate).ToPagedList(page, pagesize);
        }
        public List<categorize> ListWhereAll(String keysearch)
        {
            return db.categorizes.Where(x => x.Name_cate.Contains(keysearch)).ToList();
        }
        public String Insert(categorize enti_ca)
        {
            db.categorizes.Add(enti_ca);
            db.SaveChanges();
            return enti_ca.Name_cate;
        }
        public categorize Find(String id)
        {
            return db.categorizes.Find(id);
        }

    }
}
