namespace ApiWithWorkerRespository
{
    public interface ICommandRepository
    {
        string GetMessage();
        void SetMessage(string message);
    }
}