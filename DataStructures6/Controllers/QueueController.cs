﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures5.Controllers
{
    public class QueueController : Controller
    {
        public static Queue<string> myQueue = new Queue<string>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOne()
        {
            int i = myQueue.Count + 1;  //figure out how many items are in the queue

            myQueue.Enqueue("New Entry " + i);

            return View("Index");
        }

        public ActionResult AddHugeList()
        {
            myQueue.Clear();  //first clear the queue

            for (int i = 0; i < 2000; i++)
            {
                myQueue.Enqueue("New Entry " + (i + 1));
            }

            return View("Index");
        }

        public ActionResult Display()
        {
            if (myQueue.Count >= 1)
            {
                ViewBag.MyQueue += "<ul>";
                foreach (var item in myQueue)
                {
                    ViewBag.MyQueue += "<li>" + item + "</li>";
                }
                ViewBag.MyQueue += "</ul>";
            }
            else //handle any errors and inform the user!
            {
                ViewBag.MyQueue = "No items in Queue.";
            }

            return View("Index");
        }

        public ActionResult Delete()
        {
            if (myQueue.Count >= 1)
            {
                ViewBag.Deleted = "Deleted Record: " + myQueue.Dequeue();
            }
            else  //handle any errors and inform the user!
            {
                ViewBag.Deleted = "No items in Queue.";
            }


            return View("Index");
        }

        public ActionResult Clear()
        {
            myQueue.Clear();

            return View("Index");
        }

        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            string itemCompare = "New Entry 3";
            bool bFound = false;

            sw.Start();
            foreach (var item in myQueue)
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
                ViewBag.Found = "New Entry 3 was found in the Queue. " + "It took " + ts + " to search";
            }
            else
            {
                ViewBag.Found = "New Entry 3 was NOT found in the Queue. " + "It took " + ts + " to search";
            }

            return View("Index");
        }
    }
}