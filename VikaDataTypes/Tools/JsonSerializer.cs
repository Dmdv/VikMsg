using System;
using System.IO;
using Newtonsoft.Json;
using Vk.Interfaces;

namespace VkontakteServiceLayer.Tools
{
    public class JsonSerializer<T> where T : IServiceResult, new()
    {
        public T Deserialize(Stream stream)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(new StreamReader(stream).ReadToEnd());
            }
            catch (Exception exp)
            {
                return new T();
            }
        }
    }
}