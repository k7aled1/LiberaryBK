using LiberaryBK.Data;
using LiberaryBK.Models;
using LiberaryBK.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiberaryBK.ViewComponents
{
    public class AddCViewComponent : ViewComponent
    {

        private readonly ApplicationDbContext db;
        private readonly IComments comnt;
        public AddCViewComponent(IComments comnt, ApplicationDbContext db)
        {
            this.db = db;
            this.comnt = comnt;
        }
        public IViewComponentResult Invoke()
        {
            return View("addComn");
        }
        /*[HttpPost]
        public IViewComponentResult Invoke(Comments comments)
        {
            comnt.AddComnt(comments);
            return View("addComn");
        }*/

    }
}
