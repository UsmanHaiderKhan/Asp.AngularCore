namespace Asp.AngularCore.git.Services
{
    public interface IMailService
    {
        void Message(string to, string subject, string body);
    }
}