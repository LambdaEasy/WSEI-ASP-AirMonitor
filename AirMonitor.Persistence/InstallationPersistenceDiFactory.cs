using AirMonitor.Core.Installation;
using AirMonitor.Core.Measurement;
using AirMonitor.Persistence.Installation.Repository;
using AirMonitor.Persistence.Measurement.Repository;
using Microsoft.EntityFrameworkCore;

namespace AirMonitor.Persistence
{
    public static class InstallationPersistenceDiFactory
    {
        public static AirMonitorDbContext CreateDbContext(string connectionString)
            => new AirMonitorDbContext(CreateDbOptions(connectionString));

        
        public static IInstallationRepository CreateInstallationRepository(AirMonitorDbContext db)
        {
            InstallationDao dao = InstallationDao.Factory.Create(db);
            IInstallationRepository repository = InstallationRepository.Factory.Create(dao);
            return repository;
        }
        
        public static IMeasurementRepository CreateMeasurementRepository(AirMonitorDbContext db)
        {
            MeasurementDao dao = MeasurementDao.Factory.Create(db);
            IMeasurementRepository repository = MeasurementRepository.Factory.Create(dao);
    
            return repository;
        }

        private static DbContextOptions<AirMonitorDbContext> CreateDbOptions(string connectionString)
            => new DbContextOptionsBuilder<AirMonitorDbContext>()
                .UseSqlServer(connectionString)
                .Options;
    }
}
