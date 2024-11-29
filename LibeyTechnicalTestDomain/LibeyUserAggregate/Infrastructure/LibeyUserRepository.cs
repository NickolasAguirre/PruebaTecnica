using AutoMapper;
using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public LibeyUserRepository(Context context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Create(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Add(libeyUser);
            _context.SaveChanges();
        }



        public LibeyUserResponse FindResponse(string documentNumber)
        {

            var q = (from libeyUser in _context.LibeyUsers
                     join  ubi in _context.Ubigeos on libeyUser.UbigeoCode equals ubi.UbigeoCode
                     join reg in _context.Regions on ubi.RegionCode equals reg.RegionCode
                     join prov in _context.Provinces on ubi.ProvinceCode equals prov.ProvinceCode
                     where libeyUser.DocumentNumber.Equals(documentNumber)
                     select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        Active = libeyUser.Active,
                        Address = libeyUser.Address,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        Email = libeyUser.Email,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        ProvinceCode = prov.ProvinceCode,
                        RegionCode = reg.RegionCode,
                        UbigeoCode = libeyUser.UbigeoCode,
                        Name = libeyUser.Name,
                        Password = libeyUser.Password,
                        Phone = libeyUser.Phone
                    });
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new LibeyUserResponse();
        }

        public List<LibeyUserResponse> GetLibeyUsers()
        {
            var data = (from libeyUser in _context.LibeyUsers
                        join ubi in _context.Ubigeos on libeyUser.UbigeoCode equals ubi.UbigeoCode
                        join reg in _context.Regions on ubi.RegionCode equals reg.RegionCode
                        join prov in _context.Provinces on ubi.ProvinceCode equals prov.ProvinceCode
                        select new LibeyUserResponse
                        {
                            DocumentNumber = libeyUser.DocumentNumber,
                            Active = libeyUser.Active,
                            Address = libeyUser.Address,
                            DocumentTypeId = libeyUser.DocumentTypeId,
                            Email = libeyUser.Email,
                            FathersLastName = libeyUser.FathersLastName,
                            MothersLastName = libeyUser.MothersLastName,
                            ProvinceCode = prov.ProvinceCode,
                            RegionCode = reg.RegionCode,
                            UbigeoCode = libeyUser.UbigeoCode,
                            Name = libeyUser.Name,
                            Password = libeyUser.Password,
                            Phone = libeyUser.Phone
                        }).ToList();
            return data;
        }
        public  void Update(UserUpdateorCreateCommand command,string documentNumber)
        {
            LibeyUser? libeyUser =   _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber == documentNumber);
            if (libeyUser == null)
            {
                return;
            }
            var libeyUserDto = _mapper.Map<LibeyUser>(command);
            libeyUser.UpdateLibeyUser(libeyUserDto);
             _context.SaveChanges();

        }   


        public void Delete (string documentNumber)
        {
            LibeyUser? libeyUser = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber == documentNumber);
            if (libeyUser == null)
            {
                return;
            }
            _context.LibeyUsers.Remove(libeyUser);
            _context.SaveChanges();
        }


    }
}