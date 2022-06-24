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
        public List<Details_receipt> ListAll(int reliefId, string userId)
        {
            //return db.Registration_forms.ToList();
            return db.Details_receipt.Where(x => x.ID_receipt == reliefId && x.Receipt.Nguoitang == userId).ToList();
        }
    }
}

