using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trello_.Controllers
{
    public class CustomerCntroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
