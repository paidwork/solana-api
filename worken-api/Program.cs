
using Microsoft.OpenApi.Models;
using System.Security.Cryptography.X509Certificates;
using worken_api.Interfaces;
using PublicKey = Solnet.Wallet.PublicKey;
using worken_api.Services;

namespace worken_api
{
    public class Program
    {
        public const string WorkenMintPublicKeyString = "9tnkusLJaycWpkzojAk5jmxkdkxBHRkFNVSsa7tPUgLb";
        public static Solnet.Wallet.PublicKey WorkenMintPublicKey = new PublicKey(WorkenMintPublicKeyString);

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IWalletService, WalletService>();
           
            builder.Services.AddScoped<IRpcService, RpcService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IInstructionService, InstructionService>();
            builder.Services.AddScoped<ITransactionsService, TransactionsServices>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSwaggerGen(p =>
            {
                p.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
