using Vk.Interfaces;

namespace Vk.Serializables
{
    public class SendMessageResult : IServiceResult
    {
        public int Response { get; set; }

        public bool ResponseIsSuccess()
        {
            return Response != 0;
        }
    }
}