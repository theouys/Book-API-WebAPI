using AutoMapper;
using bookapi.Models;
using bookapi.Profiles;
using bookapi.Dtos;
namespace bookapi.Profiles
{
    public class BooksProfile : Profile
    {
      
        public BooksProfile()
        {
            CreateMap<Book,BookReadDto>();
        }

    }
}