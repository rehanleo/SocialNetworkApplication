using System;
namespace ServiceLayer
{
    public interface IController : IDisposable
    {
        void ProcessCommand(string command);
    }
}
