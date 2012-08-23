using System.Runtime.Serialization;
using Vk.Interfaces;

namespace Vk.Serializables
{
    [DataContract]
    public class GetProfiles : IServiceResult
    {
        [DataMember(Name = "response")]
        public UserServiceItem[] Result { get; set; }

        public string Error { get; set; }

        public bool ResponseIsSuccess()
        {
            return Result != null;
        }
    }
}