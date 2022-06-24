using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ReliefDao
    {
        private DB_Relief db;

        public ReliefDao()
        {
            db = new DB_Relief();
        }

        public List<Relief> ListAll()
        {
            return db.Reliefs.ToList();
        }
        public bool Detele(int id)
        {
            try
            {
                var re = db.Reliefs.Find(id);
                db.Reliefs.Remove(re);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public IEnumerable<Relief> LisWheretAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Relief> model = db.Reliefs;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Title.Contains(keysearch));
            }
            return model.OrderBy(x => x.Title).ToPagedList(page, pagesize);
        }
        public List<Relief> ListWhereAll(String keysearch)
        {
            return db.Reliefs.Where(x => x.Title.Contains(keysearch)).ToList();
        }
        public String Insert(Relief enti_re)
        {
            db.Reliefs.Add(enti_re);
            db.SaveChanges();
            return enti_re.Title;
        }

        public Relief Find(int id)
        {
            return db.Reliefs.Find(id);
        }

        public List<ReliefReport> GetReportData()
        {
            var result = new List<ReliefReport>();
            result = db.Reliefs.GroupBy(s => s.Time_sent_post.Value.Month).Select(gr => new ReliefReport
            {
                month = gr.Key,
                count = gr.Count()
            }).ToList();
            return result;
        }

    }
}
