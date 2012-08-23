using Vk.Model;

namespace VictoriaMessenger.Services
{
    public interface ICommonErrorHandler
    {
        bool HandleError(Error error);
    }
}