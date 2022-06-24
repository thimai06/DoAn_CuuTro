using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ReceiptDao
    {
        private DB_Relief db;
        public ReceiptDao()
        {
            db = new DB_Relief();
        }
        public List<Receipt> ListAll()
        {
            return db.Receipts.ToList();
        }
        public Receipt Find(int id)
        {
            return db.Receipts.Find(id);
        }
        public void Insert(Receipt enti_re)
        {
            db.Receipts.Add(enti_re);
            db.SaveChanges();
        }
        public IEnumerable<Receipt> LisWheretAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Receipt> model = db.Receipts;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Pesonal.Personal_name.Contains(keysearch) || x.Relief.Title.Contains(keysearch));
            }
            return model.OrderBy(x => x.Pesonal.Personal_name).ToPagedList(page, pagesize);
        }
        public List<Receipt> ListWhereAll(String keysearch)
        {
            return db.Receipts.Where(x => x.Pesonal.Personal_name.Contains(keysearch) || x.Relief.Title.Contains(keysearch)).ToList();
        }
    }
}
