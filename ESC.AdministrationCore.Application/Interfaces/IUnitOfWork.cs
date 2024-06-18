namespace ESC.AdministrationCore.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
    }
}