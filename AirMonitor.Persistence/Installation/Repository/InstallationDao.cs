using System.Collections.Generic;
using System.Linq;
using AirMonitor.Persistence.Installation.Entity;
using Microsoft.EntityFrameworkCore;

namespace AirMonitor.Persistence.Installation.Repository
{
    public class InstallationContext : DbContext
    {
        #region DbTables

        private DbSet<InstallationEntity> Installations { get; set; }
        private DbSet<InstallationAddressEntity> InstallationAddresses { get; set; }
        private DbSet<InstallationSponsorEntity> InstallationSponsors { get; set; }

        #endregion

        #region Constructors

        public InstallationContext(DbContextOptions options) : base(options) { }

        #endregion

        public bool ExistsByExternalId(long? id)
            => FindByExternalId(id) != null;

        public InstallationEntity Save(InstallationEntity installation)
        {
            Installations.Add(installation);
            SaveChanges();
            return installation; // TODO verify id exists on saved entity
        }

        public InstallationEntity FindById(long? id)
            => id == null
             ? null
             : Installations.Include(installation => installation.Address)
                            .Include(installation => installation.Sponsor)
                            .SingleOrDefault(installation => installation.Id == id);

        public InstallationEntity FindByExternalId(long? externalId)
            => externalId == null
             ? null
             : Installations.Include(installation => installation.Address)
                            .Include(installation => installation.Sponsor)
                            .SingleOrDefault(installation => installation.ExternalId == externalId);

        public HashSet<InstallationEntity> FindAll()
            => Installations.Include(installation => installation.Address)
                            .Include(installation => installation.Sponsor)
                            .ToHashSet();

        public HashSet<InstallationEntity> FindAllWhereLocationInAndLongitudeIn(float minLatitude,
                                                                                float maxLatitude,
                                                                                float minLongitude,
                                                                                float maxLongitude)
            => Installations.Include(installation => installation.Address)
                            .Include(installation => installation.Sponsor)
                            .Where(installation => installation.Latitude >= minLatitude && installation.Latitude <= maxLatitude)
                            .Where(installation => installation.Longitude >= minLongitude && installation.Longitude <= maxLongitude)
                            .ToHashSet();

        public bool DeleteById(long id)
        {
            InstallationEntity installation = FindById(id);
            if (installation == null)
            {
                return false;
            }
            Installations.Remove(installation);
            SaveChanges();
            return true;
        }
    }
}
