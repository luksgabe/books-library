using BooksLibrary.Application.Book.Queries;
using BooksLibrary.Application.DataTransferObjects;
using BooksLibrary.Application.Interfaces;
using BooksLibrary.Domain.Interfaces.Repository;
using BooksLibrary.Domain.Interfaces.SeedWork;
using BooksLibrary.Domain.Models;
using BooksLibrary.Infra.CrossCutting.Bus;
using BooksLibrary.Infra.CrossCutting.Integrations.Options;
using BooksLibrary.Infra.Data;
using BooksLibrary.Infra.Data.Context;
using BooksLibrary.Infra.Data.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BooksLibrary.Infra.CrossCutting.IoT
{
    public static class NativeInjectorBootstrapper
    {

        public static void RegisterApiServices(IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<IRequestHandler<GetBooksQuery, PageResult<BookDto>>, BookQueryHandler>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AppDbContext>();
        }

        public static void RegisterWorkerServices(IServiceCollection services)
        {
            services.AddSingleton<IBooksApiService, BooksApiService>();
            services.AddSingleton<IBookRepository, BookRepository>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<AppDbContext>();
        }
    }
}
