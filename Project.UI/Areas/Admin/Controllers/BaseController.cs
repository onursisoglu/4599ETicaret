using Project.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.UI.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
       public void ShowMessage(MessageType tip , string msg, byte sure=3,bool kapansinmi=true)
        {
            MessageTemplate mesaj = new MessageTemplate();

            mesaj.MessageTip = tip;
            mesaj.Content = msg;
            mesaj.Duration = sure;
            mesaj.Closeable = kapansinmi;

            TempData[MessageTemplate.tempDataName] = mesaj;


        }
    }
}