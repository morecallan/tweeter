﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tweeter.DAL;

namespace Tweeter.Controllers
{
    public class TweetController : ApiController
    {
        TweeterRepo repo = new TweeterRepo();
        // GET: api/Tweet
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Tweet/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tweet
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Tweet/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Tweet/5
        public void Delete(int id)
        {
        }
    }
}
