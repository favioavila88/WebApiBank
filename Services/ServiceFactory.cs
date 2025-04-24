using WebApiBank.Factories;
using WebApiBank.Repositories;
using WebApiBank.Services;

public static class ServiceFactory
{
    public static void RegisterServices(IServiceCollection services)
    {
        // Repositorios
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IDepositRepository, DepositRepository>();
        services.AddScoped<IWithdrawalRepository, WithdrawalRepository>();

        // Servicios
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IDepositService, DepositService>();
        services.AddScoped<IWithdrawalService, WithdrawalService>();
        services.AddScoped<ITransactionService, TransactionService>(); 

        // Factory
        services.AddScoped<ITransactionFactory, TransactionFactory>();
    }
}
