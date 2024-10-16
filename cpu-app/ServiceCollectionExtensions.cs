﻿using Database;
using Manager;
using Microsoft.Extensions.DependencyInjection;
using Resources;
using Shared.Database;

namespace Gov.Cscp.Victims.Public;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddTransient<ContractHandlers>();
        services.AddTransient<IContractRepository, ContractRepository>();

        services.AddTransient<CurrencyHandlers>();
        services.AddTransient<ICurrencyRepository, CurrencyRepository>();

        services.AddTransient<ProgramHandlers>();
        services.AddTransient<IProgramRepository, ProgramRepository>();

        services.AddTransient<InvoiceHandlers>();
        services.AddTransient<IInvoiceRepository, InvoiceRepository>();

        services.AddTransient<InvoiceLineDetailHandlers>();
        services.AddTransient<IInvoiceLineDetailRepository, InvoiceLineDetailRepository>();

        services.AddTransient<PaymentHandlers>();
        services.AddTransient<IPaymentRepository, PaymentRepository>();

        services.AddTransient<ScheduleGHandlers>();
        services.AddTransient<IScheduleGRepository, ScheduleGRepository>();

        services.AddTransient<TaskHandlers>();
        services.AddTransient<ITaskRepository, TaskRepository>();

        return services;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        // NOTE global and shared mapper should be first, since it has the prefix configurations and shared mappings
        var mapperTypes = new[] {
            typeof(GlobalMapper), typeof(SharedMapper), typeof(CurrencyRepositoryMapper), typeof(PaymentRepositoryMapper), typeof(ProgramRepositoryMapper), typeof(ContractRepositoryMapper),
            typeof(InvoiceRepositoryMapper), typeof(InvoiceLineDetailRepositoryMapper), typeof(ScheduleGRepositoryMapper)
        };
        services.AddAutoMapper(cfg => cfg.ShouldUseConstructor = constructor => constructor.IsPublic, mapperTypes);
        return services;
    }
}
