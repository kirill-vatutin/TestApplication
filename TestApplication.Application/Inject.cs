using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TestApplication.Application.Items.CreateItem;
using TestApplication.Application.Items.DeleteItem;
using TestApplication.Application.Items.GetItems;
using TestApplication.Application.Items.GetItemsExcel;
using TestApplication.Application.Items.UpdateMainInfo;

namespace TestApplication.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateItemHandler>();

        services.AddScoped<DeleteItemHandler>();

        services.AddScoped<GetItemsHandler>();
        services.AddScoped<GetItemsExcelHandler>();

        services.AddScoped<UpdateMainInfoHandler>();

        services.AddValidatorsFromAssembly(typeof(Inject).Assembly);

        return services;
    }
}
