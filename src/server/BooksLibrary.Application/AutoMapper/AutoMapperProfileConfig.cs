using AutoMapper;
using BooksLibrary.Application.DataTransferObjects;
using BooksLibrary.Domain.Entities;
using BooksLibrary.Domain.Models;

namespace BooksLibrary.Domain.AutoMapper
{
    public class AutoMapperProfileConfig : Profile
    {
        public AutoMapperProfileConfig()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<BookImage, BookImageDto>().ReverseMap();

            CreateMap<PageResult<Book>, PageResult<BookDto>>().ReverseMap();
        }
    }
}
