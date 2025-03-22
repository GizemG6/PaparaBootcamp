using AutoMapper;
using Humanizer.Localisation;
using PaparaBootcamp.Week4.Dto;
using PaparaBootcamp.Week4.Dto.Author;
using PaparaBootcamp.Week4.Dto.Genre;
using PaparaBootcamp.Week4.Entity;
using PaparaBootcamp.Week4.Features.Create;

namespace PaparaBootcamp.Week4.Common
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Book, GetAllBooksDto>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
			CreateMap<Book, GetByIdBookDto>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
			CreateMap<CreateBookDto, Book>();
			CreateMap<UpdateBookDto, Book>();

			CreateMap<Author, AuthorsBooksDto>();
			CreateMap<Author, AuthorDetailDto>();
			CreateMap<CreateAuthorDto, Author>();
			CreateMap<UpdateAuthorDto, Author>();

			CreateMap<Genre, GenresDto>();
			CreateMap<Genre, GenreDetailDto>();
			CreateMap<CreateGenreDto, Genre>();
			CreateMap<UpdateGenreDto, Genre>();
		}
	}
}
