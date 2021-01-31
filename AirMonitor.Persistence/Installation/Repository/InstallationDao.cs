using System;
using System.Collections.Generic;
using System.Linq;
using AirMonitor.Persistence.Installation.Entity;
using Microsoft.EntityFrameworkCore;

namespace AirMonitor.Persistence.Installation.Repository
{
    public class InstallationDao 
    {
        #region fields

        private readonly AirMonitorDbContext _db;

        #endregion

        #region Constructors

        private InstallationDao(AirMonitorDbContext db)
        {
            this._db = db;
        }

        #endregion

        public bool ExistsByExternalId(long? externalId)
            => externalId != null && _db.Installations.Any(installation => installation.ExternalId == externalId);

        public InstallationEntity Save(InstallationEntity installation)
        {
            _db.Installations.Add(installation);
            _db.SaveChanges();
            return installation; // TODO verify id exists on saved entity
        }

        public InstallationEntity FindById(long? id)
            => id == null
             ? null
             : _db.Installations.Include(installation => installation.Address)
                                .Include(installation => installation.Sponsor)
                                .SingleOrDefault(installation => installation.Id == id);

        public InstallationEntity FindByExternalId(long? externalId)
            => externalId == null
             ? null
             : _db.Installations.Include(installation => installation.Address)
                                .Include(installation => installation.Sponsor)
                                .SingleOrDefault(installation => installation.ExternalId == externalId);

        public HashSet<InstallationEntity> FindAll()
            => _db.Installations.Include(installation => installation.Address)
                                .Include(installation => installation.Sponsor)
                                .ToHashSet();

        public HashSet<InstallationEntity> FindAllWhereLocationInAndLongitudeIn(double minLatitude,
                                                                                double maxLatitude,
                                                                                double minLongitude,
                                                                                double maxLongitude)
            => _db.Installations.Include(installation => installation.Address)
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
            _db.Installations.Remove(installation);
            _db.SaveChanges();
            return true;
        }

        public static class Factory
        {
            public static InstallationDao Create(AirMonitorDbContext db)
                => new InstallationDao(db ?? throw new AggregateException("DatabaseContext is null"));
        }
    }
}
