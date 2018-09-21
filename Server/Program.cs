using BL2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var queue = new System.Messaging.MessageQueue(@".\private$\email-unsubscribe"))
            {
                while (true)
                {
                    //System.Environment.Exit(-1);
                    Console.WriteLine("Listening:");

                    var message = queue.Receive();

                    var bodyReader = new StreamReader(message.BodyStream);
                    var jsonBody = bodyReader.ReadToEnd();

                    var unsubscribeMessage = JsonConvert.DeserializeObject<UnsubscribeMessage>(jsonBody);

                    Console.WriteLine($"Message received & processed {unsubscribeMessage.Email}");
                }
                
            }


        }
    }
}
