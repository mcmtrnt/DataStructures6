using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures5.Controllers
{
    public class DictionaryController : Controller
    {
        public static Dictionary<string, int> myDictionary = new Dictionary<string, int>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOne()
        {
            int i = myDictionary.Count + 1; //figure out how many items are in the dictionary

            myDictionary.Add("New Entry " + i, i);

            return View("Index");
        }

        public ActionResult AddHugeList()
        {
            myDictionary.Clear(); //first clear the dictionary

            for (int i = 0; i < 2000; i++)
            {
                myDictionary.Add("New Entry " + (i + 1), i + 1);
            }

            return View("Index");
        }

        public ActionResult Display()
        {
            if (myDictionary.Count >= 1)
            {
                ViewBag.MyDictionary += "<ul>";
                foreach (KeyValuePair<string, int> item in myDictionary)
                {
                    ViewBag.MyDictionary += "<li>" + item.Key + "</li>";
                }
                ViewBag.MyDictionary += "</ul>";
            }
            else //handle any errors and inform the user!
            {
                ViewBag.MyDictionary = "No items in Dictionary.";
            }

            return View("Index");
        }

        public ActionResult Delete()
        {
            if (myDictionary.Count >= 1)
            {
                string deletedKey;
                deletedKey = myDictionary.Keys.First();
                myDictionary.Remove(myDictionary.Keys.First());
                ViewBag.Deleted = "Deleted Record: " + deletedKey;
            }
            else  //handle any errors and inform the user!
            {
                ViewBag.Deleted = "No items in Dictionary.";
            }


            return View("Index");
        }

        public ActionResult Clear()
        {
            myDictionary.Clear();

            return View("Index");
        }

        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            bool bFound = false;

            sw.Start();

            if (myDictionary.ContainsKey("New Entry 3"))
            {
                bFound = true;
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            if (bFound == true)
            {
                ViewBag.Found = "New Entry 3 was found in the Dictionary. " + "It took " + ts + " to search";
            }
            else
            {
                ViewBag.Found = "New Entry 3 was NOT found in the Dictionary. " + "It took " + ts + " to search";
            }

            return View("Index");
        }
    }
}