using Models.EF;
using PagedList;
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
            public String Insert(Product enti_re)
            {
                db.Products.Add(enti_re);
                db.SaveChanges();
                return enti_re.Name_product;
            }
            public IEnumerable<Product> LisWheretAll(string keysearch, int page, int pagesize)
            {
                IQueryable<Product> model = db.Products;
                if (!string.IsNullOrEmpty(keysearch))
                {
                    model = model.Where(x => x.Name_product.Contains(keysearch));
                }
                return model.OrderBy(x => x.Name_product).ToPagedList(page, pagesize);
            }
            public List<Product> ListWhereAll(String keysearch)
            {
                return db.Products.Where(x => x.Name_product.Contains(keysearch)).ToList();
            }
    }

}
