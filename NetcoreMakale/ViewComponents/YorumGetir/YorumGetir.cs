
using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.Repostories;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace NetcoreMakale.ViewComponents.YorumGetir
{
    public class YorumGetir:ViewComponent
    {
        //Makale ID ye göre yorumları getirir.
        YorumManager yorumManager = new YorumManager(new YorumRepository());
        UserManager User_Manager = new UserManager(new UserRepository());
        public IViewComponentResult Invoke(Makale makale)
        {

            ViewBag.makale = makale;
            var values = yorumManager.GetList(x => x.MakaleID == makale.MakaleID);

            return View(values);
        }
    }
}
