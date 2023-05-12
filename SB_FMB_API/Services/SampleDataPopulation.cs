using SB_FMB_Domain.Commons;
using SB_FMB_Domain.Entities;
using SB_FMB_Domain.Repositories.Interfaces;

namespace SB_FMB_API.Services
{
    public class SampleDataPopulationService : IHostedService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public SampleDataPopulationService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();

                var user = new User
                {
                    Username = "admin",
                    FullName = "Administrator",
                    FullNameArabic = "",
                    Password = passwordHasher.Hash("admin@5152"),
                    Mobile = "",
                    Email = "admin",
                    //IsActive = true,
                };

                await userRepository.AddAsync(user);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
