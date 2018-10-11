using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures5.Controllers
{
    public class StackController : Controller
    {
        public static Stack<string> myStack = new Stack<string>();
        string poppedString;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOne()
        {
            int i = myStack.Count + 1; //figure out how many items are in the queue

            myStack.Push("New Entry " + i);

            return View("Index");
        }

        public ActionResult AddHugeList()
        {
            myStack.Clear();  //first clear the stack

            for (int i = 0; i < 2000; i++)
            {
                myStack.Push("New Entry " + (i + 1));
            }

            return View("Index");
        }

        public ActionResult Display()
        {
            if (myStack.Count >= 1)
            {
                ViewBag.MyStack += "<ul>";
                foreach (var item in myStack)
                {
                    ViewBag.MyStack += "<li>" + item + "</li>";
                }
                ViewBag.MyStack += "</ul>";
            }
            else //handle any errors and inform the user!
            {
                ViewBag.MyStack = "No items in Stack.";
            }

            return View("Index");
        }

        public ActionResult Delete()
        {
            if (myStack.Count >= 1)
            {
                poppedString = myStack.Pop();
                ViewBag.Deleted = "Deleted Record: " + poppedString;
            }
            else  //handle any errors and inform the user!
            {
                ViewBag.Deleted = "No items in Stack.";
            }


            return View("Index");
        }

        public ActionResult Clear()
        {
            myStack.Clear();

            return View("Index");
        }

        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            string itemCompare = "New Entry 3";
            bool bFound = false;

            sw.Start();
            foreach (var item in myStack)
            {
                if (itemCompare == item)
                {
                    bFound = true;
                }
            }
            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            if (bFound == true)
            {
                ViewBag.Found = "New Entry 3 was found in the Stack. " + "It took " + ts + " to search";
            }
            else
            {
                ViewBag.Found = "New Entry 3 was NOT found in the Stack. " + "It took " + ts + " to search";
            }

            return View("Index");
        }

    }
}