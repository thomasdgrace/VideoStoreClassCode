using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStoreNew.Services
{
    public class HardcodedMessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hardcoded Message from a Service";
        }
    }
}
