using System.Runtime.Serialization;

namespace Vk.Serializables
{
    [DataContract]
    public class PhotoAlbum
    {
        [DataMember(Name = "aid")]
        public string Aid { get; set; }

        [DataMember(Name = "thumb_id")]
        public string ThumbID { get; set; }

        [DataMember(Name = "owner_id")]
        public string OwnerID { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "created")]
        public string Created { get; set; }

        [DataMember(Name = "updated")]
        public string Updated { get; set; }

        [DataMember(Name = "size")]
        public string Size { get; set; }

        [DataMember(Name = "privacy")]
        public string Privacy { get; set; }
    }
}