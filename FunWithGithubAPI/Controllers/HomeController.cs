using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using FunWithGithubAPI.ViewModels;

namespace FunWithGithubAPI.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            string repoJson = null;

            HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create("https://api.github.com/users/davekoregon/repos");
            webReq.Headers = new WebHeaderCollection() { "User-Agent: DaveKOregon" };

            using (WebResponse webResp = webReq.GetResponse())
            {
                using (Stream str = webResp.GetResponseStream())
                {
                    using (StreamReader sRdr = new StreamReader(str))
                    {
                        repoJson = sRdr.ReadToEnd();
                    }
                }
            }

            IEnumerable<HomeViews.Repo> repoData = JsonConvert.DeserializeObject<HomeViews.Repo[]>(repoJson);

            HomeViews.Index Index = new HomeViews.Index()
            {
                Repos = repoData
                    .OrderByDescending(r => r.stargazers_count)
                    .ThenBy(r => r.name)
                    .Take(5)
                    .ToList()
            };

            return View(Index);
        }
    }
}