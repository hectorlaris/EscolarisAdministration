using ESC.AdministrationCore.Application.Interfaces;

namespace ESC.AdministrationCore.Infraestructure
{ 
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IUserRepository userRepository)
        {
            Users = userRepository;
        }

        public IUserRepository Users { get; set; }
    }
}