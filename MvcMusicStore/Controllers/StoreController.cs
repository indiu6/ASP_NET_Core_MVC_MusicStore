using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    // display music available for users to add to their shopping cart
    public class StoreController : Controller
    {
        // Index is the default action for this controller
        // in the Store controller, this will list genres
        // of music to select from
        public IActionResult Index()
        {
            //return "Hello from store Index()";

            // create/change a cookie called "artistId"
            // - exists in memory for duration of the browser session
            //   - unless you give it an expiry date
            //Response.Cookies.Append("artistId", artistId.ToString(), new CookieOptions { Expires = DateTime.Today.AddDays(20) });
            Response.Cookies.Append("ArtistName", "New Artist on the block", new CookieOptions { Expires = DateTime.Today.AddDays(20)});

            // create or change session variables
            HttpContext.Session.SetInt32("ArtistId", 100);
            //HttpContext.Session.SetInt32(nameof(artistId), artistId);
            //HttpContext.Session.SetString("artistName", artistName)

            return RedirectToAction("RequestStuff", "Store", new {contact = "Email", userName = "John"});
        }

        // Action to browse all albums available for the selected genre
        // - allows users to select albums to see their details
        public string Browse(String genre)
        {
            // Can also reference QueryString variables in code: 
            //Request.Query["genre"].FirstOrDefault();

            return $"you're browsing for albums of the Genre: {genre}";
        }

        // action to display the details of a selected album
        public string Details(Int32 id)
        {

            return $"Album key provided is: {id}";
        }

        // sample action for View examples
        public IActionResult Sample()
        {
            ViewBag.message = "this is ViewBag property 'message'";
            return View();
        }

        // return a collection of generic album titles
        public IActionResult List()
        {
            List<Album> albums = new List<Album>();
            for (int i = 0; i < 10; i++)
            {
                albums.Add(new Album { Title = "Generic Album " + i });
            }
            //ViewBag.Albums = albums; // create new entry in ViewData
            return View(albums); // render ~/Views/Store/List.cshtml
        }

        public IActionResult Guest()
        {
            return View();
        }

        public IActionResult RequestStuff(string user)
        {
            //if (user != null) HttpContext.Session.SetString("user", user);
            //var userName = Request.Query["user"];
            var userName = "TestUser";

            ViewData["Message"] = $"Your application description page, '{userName}'";
            Response.Cookies.Append("userName", userName);
            List<Generic2String> headers = new List<Generic2String>();
            foreach (var item in Request.Headers.Keys)
            {
                headers.Add(new Generic2String($"Request.Headers['{item}']", Request.Headers[item]));
            }
            headers.Add(new Generic2String("Request.Headers['Referer']", Request.Headers["Referer"]));
            headers.Add(new Generic2String("Request.Host", Request.Host.ToString()));
            foreach (var item in Request.Cookies.Keys)
            {
                headers.Add(new Generic2String($"Request.Cookies['{item}']", Request.Cookies[item]));
            }
            headers.Add(new Generic2String("Request.HttpContext.Connection.LocalIpAddress (user IP)",
                        Request.HttpContext.Connection.LocalIpAddress.ToString()));
            headers.Add(new Generic2String("Request.HttpContext.Connection.LocalPort (user TCP port)",
                        Request.HttpContext.Connection.LocalPort.ToString()));
            headers.Add(new Generic2String("Request.HttpContext.Connection.RemoteIpAddress (server IP)",
                        Request.HttpContext.Connection.RemoteIpAddress.ToString()));
            headers.Add(new Generic2String("Request.HttpContext.Connection.RemotePort (server TCP port)",
                        Request.HttpContext.Connection.RemotePort.ToString()));
            //headers.Add(new Generic2String("Request.HttpContext.Session.Id", Request.HttpContext.Session.Id.ToString()));
            headers.Add(new Generic2String("Request.IsHttps", Request.IsHttps.ToString()));
            headers.Add(new Generic2String("Request.Method", Request.Method.ToString()));
            headers.Add(new Generic2String("Request.Path", Request.Path.ToString()));
            headers.Add(new Generic2String("Request.Protocol", Request.Protocol.ToString()));
            headers.Add(new Generic2String("Request.QueryString", Request.QueryString.ToString()));
            headers.Add(new Generic2String("Request.Query", Request.Query.ToString()));
            foreach (var item in Request.Query)
            {
                headers.Add(new Generic2String($"Request.Query['{item.Key}']", item.Value));
            }

            //
            string ArtistName = Request.Cookies["ArtistName"].ToString();
            headers.Add(new Generic2String("Artist Name", ArtistName));

            // check if session variables exist before converting them:
            //if (HttpContext.Session.GetInt32(nameof(ArtistId)) != null)
            //{
            //    artistId = Convert.ToInt32(HttpContext.Session.GetInt32(nameof(artistId)));
            //    artistName = HttpContext.Session.GetString(nameof(artistName));
            //}
            //int ArtistId = Convert.ToInt32(HttpContext.Session.GetInt32("ArtistId"));
            //headers.Add(new Generic2String("ArtistId", ArtistId.ToString()));

            //
            TempData["message"] = "In RequestStuff. All good";

            return View(headers);
        }
    }

}
