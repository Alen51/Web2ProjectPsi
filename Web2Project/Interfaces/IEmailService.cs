namespace Web2Project.Interfaces
{
    public interface IEmailService
    {
        void SendVerificationMail(string prodavacMail, string statusVerifikacije);
    }
}
