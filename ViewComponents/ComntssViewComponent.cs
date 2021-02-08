using LiberaryBK.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiberaryBK.Data;
using LiberaryBK.Models;

namespace LiberaryBK.ViewComponents
{
    public class ComntsViewComponent : ViewComponent
    {
        private readonly IComments comnt;
        private readonly ApplicationDbContext db;

        public ComntsViewComponent(IComments comnt, ApplicationDbContext db)
        {
            this.comnt = comnt;
            this.db = db;
        }

        public IViewComponentResult Invoke(int Id)
        {
            return View("comnts",comnt.GetComntsByBookId(Id));
        }
    }
}
