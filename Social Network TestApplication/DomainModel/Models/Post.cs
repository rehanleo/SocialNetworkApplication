﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Post
    {
        public string User { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
    }
}
