using AutoMapper;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;
        private readonly IMapper _mapper;
        public LibeyUserAggregate(ILibeyUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public void Create(UserUpdateorCreateCommand command)
        {
            LibeyUser user = _mapper.Map<LibeyUser>(command);
            _repository.Create(user);
        }
        
        public void Update(UserUpdateorCreateCommand command,string DocumentNumber)
        {
            _repository.Update(command, DocumentNumber);
        }

        public void Delete(string DocumentNumber)
        {
            _repository.Delete(DocumentNumber);
        }

        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }

        public List<LibeyUserResponse> GetLibeyUsers()
        {
            var row = _repository.GetLibeyUsers();
            return row;
        }



    }
}