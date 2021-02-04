using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio2021.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using System.Text;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Azure.Storage;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Portfolio2021.Controllers
{
    public class HomeController : Controller
    {
        private readonly Settings _settings;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IOptionsSnapshot<Settings> settings)
        {
            _logger = logger;
            _settings = settings.Value;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public JsonResult DoSomething([FromBody] QueueMessage queueMessage)
        {
            string connectionString = _settings.evanallen13StorageConnectionString;
            string queueName = "contactform";
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            var plainTextBytes = Encoding.UTF8.GetBytes(queueMessage.MessageJson().ToString());
            var message = System.Convert.ToBase64String(plainTextBytes);

            // Create the queue if it doesn't already exist
            //queueClient.CreateIfNotExists();

            if (queueClient.Exists())
            {
                // Send a message to the queue
                queueClient.SendMessage(message.ToString());
            }
            return Json("Success");
        }
    }
}
