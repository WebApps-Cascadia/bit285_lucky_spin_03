using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
//TODO: import the LuckySpin.Models namespace into the Controller with a "using" command
using LuckySpin.Models;
using System.Numerics;

namespace LuckySpin.Controllers
{
    public class SpinnerController : Controller
    {
        /***
        * Controller Actions - GET and POST
        *   GET request for Index diplays the Player form
        *   POST request for Index gathers the Player info collected by the form and Redirect to Spin
        *   GET request for Spin is called by the RedirectToAction method, not the user
        *
        *
        * Index Action - displays the Player form; then gathers from POST to create a Player object
        **/
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Player player)
        {
            return View();
        }

        /***
         * Spin Action - displays the Spin View passing a new Spin including the Player info
         **/
        [HttpGet]
        public IActionResult Spin(int luck)
        {
            Random random = new Random();

            //Create a new spin object from the Model class Spin
            Spin spin = new Spin
            {
                //TODO: Assign Spin properties according to Model changes
                //Luck = luck,
                Numbers = new int[] { random.Next(1, 9), random.Next(1, 9), random.Next(1, 9) }
            };

            //Assigns ImageShown property to the appropiate CSS display value (either "block" or "none")
            if (Array.Exists(spin.Numbers, n => n == 7))
                spin.ImageDisplay = "block";
            else
                spin.ImageDisplay = "none";

            return View( spin );
        }
    }
}