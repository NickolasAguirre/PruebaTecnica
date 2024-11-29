using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserRepository
    {
        List<LibeyUserResponse> GetLibeyUsers();

        LibeyUserResponse FindResponse(string documentNumber);
        void Create(LibeyUser libeyUser);
        void Update(UserUpdateorCreateCommand libeyUser,string documentNumber);
        void Delete(string documentNumber);
    }
}
