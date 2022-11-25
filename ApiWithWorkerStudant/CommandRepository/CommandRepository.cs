using System;

namespace ApiWithWorkerRespository
{
    public class CommandRepository : ICommandRepository
    {
        private string _message;

        public CommandRepository()
        {
            _message = "...";
        }

        public string GetMessage()
        {
            return _message;
        }

        public void SetMessage(string message)
        {
            _message = message;
        }
    }
}
