using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunWithGithubAPI.ViewModels
{
    public class HomeViews
    {
        public class Repo
        {
            public string id { get; set; }
            public string name { get; set; }
            public string full_name { get; set; }
            public string html_url { get; set; }
            public int stargazers_count { get; set; }
        }

        public class Index
        {
            public List<Repo> Repos { get; set; }
        }
    }
}
