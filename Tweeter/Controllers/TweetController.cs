﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using Tweeter.DAL;
using Tweeter.Models;
using Microsoft.AspNet.Identity.Owin;

namespace Tweeter.Controllers
{
    public class TweetController : ApiController
    {
        ApplicationUserManager userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        TweeterRepo repo = new TweeterRepo();


        // GET: api/Tweet
        public IEnumerable<Tweet> Get()
        {
            return repo.GetAllTweets();
        }

        // GET: api/Tweet/5
        public IEnumerable<Tweet> Get(int id)
        {
            return repo.GetAllUserSpecificTweets(id);
        }


        // PUT: api/Tweet/5
        public void Post([FromBody]TweetViewModel tweet)
        {
            ApplicationUser user = userManager.FindById(User.Identity.GetUserId());

            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {
                Twit twit_author = repo.FindTwitBasedOnApplicationUser(user);
                repo.AddTwitToDatabase(user);
                Tweet new_tweet = new Tweet
                {
                    Message = tweet.Message,
                    ImageURL = tweet.ImageURL,
                    Author = twit_author,
                    CreatedAt = DateTime.Now
                };
                repo.AddTweet(new_tweet);
            }
        }

        // DELETE: api/Tweet/5
        public void Delete(int id)
        {
            ApplicationUser user = userManager.FindById(User.Identity.GetUserId());
            Twit twit_author = repo.FindTwitBasedOnApplicationUser(user);

            Tweet tweet_to_delete = repo.GetTweetById(id);
            if (tweet_to_delete.Author == twit_author)
            {
                repo.DeleteSpecificTweet(id);
            }
            else
            {
                throw new Exception("User is not logged in");
            }
        }
    }
}
