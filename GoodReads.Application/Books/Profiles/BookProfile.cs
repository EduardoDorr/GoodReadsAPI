using AutoMapper;

using GoodReads.Domain.Books;
using GoodReads.Application.Books.Models;
using GoodReads.Application.Books.CreateBook;

namespace GoodReads.Application.Books.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<CreateBookCommand, Book>();
        CreateMap<Book, BookViewModel>();
        CreateMap<Book, BookWithRatingsViewModel>();
    }
}