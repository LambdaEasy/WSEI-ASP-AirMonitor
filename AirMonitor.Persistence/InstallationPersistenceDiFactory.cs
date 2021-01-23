using AirMonitor.Core.Installation;
using AirMonitor.Persistence.Installation.Repository;
using Microsoft.EntityFrameworkCore;

namespace AirMonitor.Persistence
{
    public static class InstallationPersistenceDiFactory
    {
        public static IInstallationRepository CreateInstallationRepository(string connectionString)
        {
            var options = new DbContextOptionsBuilder<AirMonitorDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            AirMonitorDbContext db = new AirMonitorDbContext(options);
            InstallationDao dao = InstallationDao.Factory.Create(db);
            IInstallationRepository repository = InstallationRepository.Factory.Create(dao);

            return repository;
        }
    }
}
