using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Vk.Interfaces;

namespace Vk.Serializables
{
    [DataContract]
    public class GetMessagesHistory : IServiceResult
    {
        [DataMember(Name = "response")]
        public List<Object> Response { get; set; }

        public List<MessageHistory> Messages
        {
            get
            {
                if (Response == null) return null;
                return
                    Response.Skip(1).Select(i => JsonConvert.DeserializeObject<MessageHistory>(i.ToString())).ToList();
            }
        }

        public Int64 Count
        {
            get { return (Int64) Response.First(); }
        }

        public bool ResponseIsSuccess()
        {
            return Messages != null;
        }
    }
}