﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tweeter.Models
{
    public class TweetViewModel
    {
        [Required]
        [MinLength(2)]
        public string Message { get; set; }

        [Url(ErrorMessage = "Please enter a valid image url")]
        public string ImageURL { get; set; }
    }
}