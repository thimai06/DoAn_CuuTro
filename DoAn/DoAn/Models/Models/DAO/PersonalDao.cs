using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models.DAO
{

     public class PersonalDao
    {
        const int LoginSuccess = 0;
        const int IsNotExistAccount = 1;
        const int IsWrongPasswords = 2;

        private DB_Relief db;

        public PersonalDao()
        {
            db = new DB_Relief();
        }
        public int login(String user, string pass)
        {
            var result = db.Pesonals.SingleOrDefault(x => x.ID_user.Contains(user) && x.password.Contains(pass));
            if (result == null)
            {
                return IsNotExistAccount;
            }
            else
            {
                if (result.password.Equals(pass))
                {
                    return LoginSuccess;
                }
                else
                {
                    return IsWrongPasswords;
                }
            }
        }

        public List<Pesonal> ListAll()
        {
            return db.Pesonals.ToList();
        }
        public IEnumerable<Pesonal> LisWheretAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Pesonal> model = db.Pesonals;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Personal_name.Contains(keysearch) || x.Address.Contains(keysearch));
            }
            return model.OrderBy(x => x.Personal_name).ToPagedList(page, pagesize);
        }
        public List<Pesonal> ListWhereAll(String keysearch)
        {
            return db.Pesonals.Where(x => x.Personal_name.Contains(keysearch) || x.Address.Contains(keysearch)).ToList();
        }
        public String Insert(Pesonal enti_pe)
        {
            db.Pesonals.Add(enti_pe);
            db.SaveChanges();
            return enti_pe.Personal_name;
        }
        //public Pesonal ViewDetail(String id)
        //{
        //    return db.Pesonals.Find(id);
        //}
        public Pesonal Find(string id)
        {
            return db.Pesonals.Find(id);
        }
        public bool Detele(string id)
        {
            try
            {
                Pesonal pe = db.Pesonals.Find(id);
                db.Pesonals.Remove(pe);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
