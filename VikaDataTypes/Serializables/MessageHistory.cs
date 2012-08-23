using System.Runtime.Serialization;

namespace Vk.Serializables
{
    [DataContract(Name = "message")]
    public class MessageHistory
    {
        [DataMember(Name = "body")]
        public string Body { get; set; }

        [DataMember(Name = "mid")]
        public string Mid { get; set; }

        [DataMember(Name = "from_id")]
        public string Uid { get; set; }

        [DataMember(Name = "date")]
        public string Date { get; set; }

        [DataMember(Name = "read_state")]
        public string ReadState { get; set; }
    }
}