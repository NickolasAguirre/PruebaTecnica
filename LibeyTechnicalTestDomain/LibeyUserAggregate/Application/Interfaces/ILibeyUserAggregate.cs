using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserAggregate
    {
        List<LibeyUserResponse> GetLibeyUsers();
        LibeyUserResponse FindResponse(string documentNumber);
        void Create(UserUpdateorCreateCommand command);
        void Update(UserUpdateorCreateCommand command,string documentNumber);
        void Delete(string documentNumber);
    }
}