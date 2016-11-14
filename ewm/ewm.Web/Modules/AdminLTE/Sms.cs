using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace ewm.Modules.AdminLTE {
    public class Sms {

        public static void SendSms(List<string> numbers, string msg) {
            foreach (string number in numbers) {

                SmsMessage temp = new SmsMessage() {
                    To = number,
                    Text = msg,
                };

                SendSMS(temp);
            }
        }

        public static void SendSMS(SmsMessage sms) {
            string api_key = System.Configuration.ConfigurationManager.AppSettings["api_key"];
            string api_secret = System.Configuration.ConfigurationManager.AppSettings["api_secret"];


            string uri = string.Format("https://rest.nexmo.com/sc/us/alert/json?api_key={0}&api_secret={1}&to={2}&systemchanges={3}", api_key, api_secret, sms.To, sms.Text.Replace(" ", "+"));
            var json = new WebClient().DownloadString(uri);
        }

        private void ParseSmsResponseJson(string json) {
            // hyphens are not allowed in in .NET var names
            json = json.Replace("message-count", "MessageCount");
            json = json.Replace("message-price", "MessagePrice");
            json = json.Replace("message-id", "MessageId");
            json = json.Replace("remaining-balance", "RemainingBalance");
        }


        public class SmsMessage : Sms {
            public string To { get; set; }
            public string Text { get; set; }
            public string Messageprice { get; set; }
            public string Status { get; set; }
            public string MessageId { get; set; }
            public string RemainingBalance { get; set; }
        }

        public class SmsResponse {
            public string Messagecount { get; set; }
            public List<SmsMessage> Messages { get; set; }
        }


        
    }
}