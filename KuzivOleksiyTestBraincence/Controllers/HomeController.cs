using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KuzivOleksiyTestBrainence.Contracts;
using KuzivOleksiyTestBrainence.DataAcess;
using KuzivOlksiyTestBraincence_Models;

namespace KuzivOleksiyTestBraincence.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      using (IUnitOfWork<Sentence> db = new UnitOfWork())
      {
        var sentences = db.Repository.GetAll(x => true);
        return View(sentences);
      }      
    }

    public JsonResult Upload(string word)
    {
      if (word != null)
      {
        for (int i = 0; i < Request.Files.Count; i++)
        {
          HttpPostedFileBase file = Request.Files[i];
          BinaryReader b = new BinaryReader(file.InputStream);
          byte[] binData = b.ReadBytes(file.ContentLength);
          string text = System.Text.Encoding.UTF8.GetString(binData);
          var reversWord = Reverse(word);
          using (IUnitOfWork<Sentence> db = new UnitOfWork())
          {
            foreach (var item in text.Split('.'))
            {
              if (item.ToLower().Contains(reversWord))
              {
                db.Repository.Add(new Sentence() { Date = DateTime.Now.ToShortDateString(), SearchWord = word, Text = item });
                db.Save();

              }
            }
            var senteces = db.Repository.GetAll(x => true);
          }
        }
        return Json("Uploaded succesfully");
      }
      return Json("Upload not succesfully");
    }

    public ActionResult About()
    {
      ViewBag.Message = "Kuziv Oleksiy About";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Kuziv Oleksiy contact.";

      return View();
    }

    public static string Reverse(string s)
    {
      char[] charArray = s.ToCharArray();
      Array.Reverse(charArray);
      return new string(charArray);
    }
  }
}