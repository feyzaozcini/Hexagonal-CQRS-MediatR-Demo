using HexagonalSample.Application.PrimaryPorts.CategoryPorts;
using HexagonalSample.Application.UseCases.CategoryUseCases;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DependencyResolvers
{
    public static class UseCaseResolver
    {
        public static void AddUseCaseService(this IServiceCollection services)
        {
            //services.AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>();
            //services.AddScoped<IUpdateCategoryUseCase, UpdateCategoryUseCase>();
            //services.AddScoped<IRemoveCategoryUseCase, RemoveCategoryUseCase>();
            //services.AddScoped<IGetAllCategoriesUseCase, GetAllCategoriesUseCase>();
            //services.AddScoped<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();

            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(GetAllCategoriesUseCase).Assembly));
        }
    }
}
