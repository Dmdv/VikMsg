using System.Collections.Generic;
using System.Linq;
using Vk.Model;
using VkontakteServiceLayer.Tools;

namespace Vk.Serializables
{
    public static class ServiceItemExtensions
    {
        public static User GetUserItem(this UserServiceItem userServiceItem)
        {
            var result = new User
                             {
                                 BrithDate = userServiceItem.BrithDate,
                                 City = userServiceItem.City,
                                 Country = userServiceItem.Country,
                                 Domain = userServiceItem.Domain,
                                 Faculty = userServiceItem.Faculty,
                                 FacultyName = userServiceItem.FacultyName,
                                 FirstName = userServiceItem.FirstName,
                                 Graduation = userServiceItem.Graduation,
                                 HasMobile = userServiceItem.HasMobile,
                                 HomePhone = userServiceItem.HomePhone,
                                 LastName = userServiceItem.LastName,
                                 MobilePhone = userServiceItem.MobilePhone,
                                 Nickname = userServiceItem.Nickname,
                                 Online = userServiceItem.Online == "1",
                                 Photo = userServiceItem.Photo,
                                 PhotoBig = userServiceItem.PhotoBig,
                                 PhotoMedium = userServiceItem.PhotoMedium,
                                 Rate = userServiceItem.Rate,
                                 Sex = userServiceItem.Sex,
                                 Timezone = userServiceItem.Timezone,
                                 Uid = userServiceItem.Uid,
                                 University = userServiceItem.University,
                                 UniversityName = userServiceItem.UniversityName
                             };
            return result;
        }

        public static List<User> GetUserItems(this UserServiceItem[] userServiceItems)
        {
            if (userServiceItems == null) return null;
            return userServiceItems.Select(serviceItem => serviceItem.GetUserItem()).ToList();
        }

        public static Vk.Model.Message GetMessageItem(this Message message)
        {
            var result = new Vk.Model.Message
                             {
                                 Title = message.Title,
                                 Uid = message.Uid,
                                 Body = message.Body,
                                 Date = UnixTimeConvertor.ConvertFromUnixTimestamp(message.Date),
                                 Mid = message.Mid,
                                 IsNewMessage = message.ReadState == "0",
                                 IsOut = message.Out == "1",
                             };
            return result;
        }

        public static Vk.Model.Message GetMessageItem(this MessageHistory message,
                                                                           string currentUid)
        {
            var result = new Vk.Model.Message
                             {
                                 Title = message.Body,
                                 Uid = message.Uid,
                                 Body = message.Body,
                                 Date = UnixTimeConvertor.ConvertFromUnixTimestamp(message.Date),
                                 Mid = message.Mid,
                                 IsNewMessage = message.ReadState == "0",
                                 IsOut = message.Uid == currentUid,
                             };
            return result;
        }

        public static List<Vk.Model.Message> GetMessageItems(this List<Message> listMessages)
        {
            if (listMessages == null) return null;
            return listMessages.Select(i => i.GetMessageItem()).ToList();
        }

        public static List<Vk.Model.Message> GetMessageItems(
            this List<MessageHistory> listMessages, string uid)
        {
            if (listMessages == null) return null;
            return listMessages.Select(i => i.GetMessageItem(uid)).ToList();
        }


        public static Vk.Model.PhotoAlbum GetPhotoAlbumItem(this PhotoAlbum photoAlbum)
        {
            var result = new Vk.Model.PhotoAlbum
                             {
                                 AlbumId = photoAlbum.Aid,
                                 Created = UnixTimeConvertor.ConvertFromUnixTimestamp(photoAlbum.Created),
                                 Updated = UnixTimeConvertor.ConvertFromUnixTimestamp(photoAlbum.Updated),
                                 Description = photoAlbum.Description,
                                 OwnerID = photoAlbum.OwnerID,
                                 ThumbID = photoAlbum.ThumbID,
                                 Title = photoAlbum.Title,
                                 Privacy = photoAlbum.Privacy,
                                 Size = photoAlbum.Size,
                             };
            return result;
        }


        public static List<Vk.Model.PhotoAlbum> GetPhotoAlbumItem(this List<PhotoAlbum> listAlbums)
        {
            if (listAlbums == null) return null;
            return listAlbums.Select(i => i.GetPhotoAlbumItem()).ToList();
        }

        public static Vk.Model.Photo GetPhotoItem(this Photo photo)
        {
            var result = new Vk.Model.Photo
                             {
                                 Aid = photo.Aid,
                                 Created = UnixTimeConvertor.ConvertFromUnixTimestamp(photo.Created),
                                 OwnerID = photo.OwnerID,
                                 Pid = photo.Pid,
                                 Source = photo.Source,
                                 SourceBig = photo.SourceBig,
                                 SourceSmall = photo.SourceSmall,
                                 SourceXbig = photo.SourceXbig,
                                 SourceXxbig = photo.SourceXxbig,
                             };

            return result;
        }

        public static List<Vk.Model.Photo> GetPhotoItems(this List<Photo> photos)
        {
            if (photos == null) return null;
            return photos.Select(i => i.GetPhotoItem()).ToList();
        }
    }
}