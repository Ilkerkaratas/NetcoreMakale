using DataAccesLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repostories
{
    public class UserRepository : GenericRepostory<User>, IUserDAL
    {
        public bool Varmi(string ad, string Sifre)
        {
            Context db = new Context();

            var value = db.Set<User>().Where(x => x.KullaniciAdi == ad && x.Sifre == Sifre);


            if (value == null)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
