﻿using System;
using System.Collections.Generic;
using System.Text;

namespace piaine
{
    public struct Post
    {
        public string name;
        public DateTime date;
        public string path;
        public pageType typeOfPage;
        public List<string> tags;
    }

    public enum pageType
    {
        post,
        staticpage
    }
}
