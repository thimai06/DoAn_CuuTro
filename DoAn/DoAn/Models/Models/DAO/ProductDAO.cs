using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{

        public class ProductDAO
        {
            private DB_Relief db;
            public ProductDAO()
            {
                db = new DB_Relief();
            }
            public List<Product> ListAll()
            {
                return db.Products.ToList();
            }
            public Product Find(string id)
            {
                return db.Products.Find(id);
            }
            //public String Insert(Receipt enti_re)
            //{
            //    db.Receipts.Add(enti_re);
            //    db.SaveChanges();
            //    return enti_re.Pesonal.ID_user;
            //}
            //public IEnumerable<Receipt> LisWheretAll(string keysearch, int page, int pagesize)
            //{
            //    IQueryable<Receipt> model = db.Receipts;
            //    if (!string.IsNullOrEmpty(keysearch))
            //    {
            //        model = model.Where(x => x.Pesonal.Personal_name.Contains(keysearch) || x.Relief.Title.Contains(keysearch));
            //    }
            //    return model.OrderBy(x => x.Pesonal.Personal_name).ToPagedList(page, pagesize);
            //}
            //public List<Receipt> ListWhereAll(String keysearch)
            //{
            //    return db.Receipts.Where(x => x.Pesonal.Personal_name.Contains(keysearch) || x.Relief.Title.Contains(keysearch)).ToList();
            //}
        }

}
