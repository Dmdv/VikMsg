using System.Runtime.Serialization;
using Vk.Interfaces;

namespace Vk.Serializables
{
    [DataContract]
    public class GetPhotos : IServiceResult
    {
        [DataMember(Name = "response")]
        public Photo[] Photos { get; set; }

        public bool ResponseIsSuccess()
        {
            return Photos != null;
        }
    }
}