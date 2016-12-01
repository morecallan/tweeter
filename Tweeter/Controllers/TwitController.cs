using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tweeter.DAL;
using Tweeter.Models;

namespace Tweeter.Controllers
{
    public class TwitController : Controller
    {
        TweeterRepo repo = new TweeterRepo();


        // GET: Twit
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TwitUser(string username)
        {
            Twit twit_to_display = repo.GetTwitBasedOnUserName(username);
            List<Tweet> tweets_to_display = repo.GetAllUserSpecificTweets(twit_to_display.TwitId);
            int number_of_following = twit_to_display.Follows.ToList().Count();
            ViewBag.username = username;
            ViewBag.number_of_following = number_of_following;
            ViewBag.twit_to_display = twit_to_display;
            ViewBag.tweets_to_display = tweets_to_display;
            return View();
        }
    }
}