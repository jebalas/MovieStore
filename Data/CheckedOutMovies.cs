﻿using System;
using Microsoft.AspNetCore.Identity;

namespace MovieLab24.Data
{
    public class CheckedOutMovies
    {
        
        public int Id { get; set; }
        public string UserID { get; set; }
        public IdentityUser User { get; set; }
        public int MovieID { get; set; }
        public Movies Movie { get; set; }
        public DateTime DueDate { get; set; }
    }
}
