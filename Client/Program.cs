using BL2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //System.Environment.Exit(-1);
                Console.WriteLine("Please enter your email:");
                var email = Console.ReadLine();

                using (var queue = new System.Messaging.MessageQueue(@".\private$\email-unsubscribe"))
                {
                    var unsubscribeMessage = new UnsubscribeMessage() { Email = email };

                    var message = new Message();
                    var jsonBody = JsonConvert.SerializeObject(unsubscribeMessage);
                    message.BodyStream = new MemoryStream(Encoding.Default.GetBytes(jsonBody));
                    queue.Send(message);
                }
                Console.WriteLine("Message sent");
            }
        }
    }
}
