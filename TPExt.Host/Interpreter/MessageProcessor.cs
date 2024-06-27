using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPExt.Host.Model;
using TPExt.Host.Result;

namespace TPExt.Host.Interpreter
{
    public class MessageProcessor
    {
        public string ProcessMessage(JObject data)
        {
            try
            {
                var message = data["text"].Value<string>().ToUpper();

                switch (message)
                {
                    case "ABORT":
                        {
                            Environment.Exit(0);
                            return "abort";
                        }
                    case "ENVIRONMENTINFO":
                        {
                            var result = GetEnvironmentInfo();
                            return JsonConvert.SerializeObject(result);
                        }
                    default:
                        {
                            var result = new BaseResult()
                            {
                                ProcessOk = false,
                                MessageReceived = false,
                                Msg = "O comando não foi reconhecido pelo host",
                            };
                            return JsonConvert.SerializeObject(result);
                        }
                }
            }
            catch (Exception ex)
            {
                var result = new BaseResult()
                {
                    ProcessOk = false,
                    MessageReceived = false,
                    MsgCatch = ex.Message,
                };

                return JsonConvert.SerializeObject(result);
            }
        }

        private EnvironmentInfoResult GetEnvironmentInfo()
        {
            var environmentInfo = new EnvironmentInfo();
            return new EnvironmentInfoResult() { ProcessOk = true, MessageReceived = true, Content = environmentInfo};
        }
    }
}
