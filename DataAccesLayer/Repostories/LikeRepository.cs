using DataAccesLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repostories
{
    public class LikeRepository : GenericRepostory<Like>, ILikeDAL
    {
        public bool varmi(int id)
        {

            Context db = new Context();
            try
            {
                var value = db.Set<Like>().Where(x => x.LikeID==id);
                return true;
            }
            catch
            {
                return false;
            };

        }
    }
}
