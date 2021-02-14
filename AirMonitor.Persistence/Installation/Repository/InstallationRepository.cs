using System;
using System.Collections.Generic;
using System.Linq;
using AirMonitor.Core.Installation;
using AirMonitor.Persistence.Installation.Entity;
using AirMonitor.Util.Flow;
using InstallationDomain = AirMonitor.Domain.Installation.Installation;

namespace AirMonitor.Persistence.Installation.Repository
{
    public class InstallationRepository : IInstallationRepository
    {
        private readonly InstallationDao _installationDao;

        private InstallationRepository(InstallationDao installationDao)
        {
            this._installationDao = installationDao;
        }

        // TODO log
        public Option<InstallationDomain> TrySave(InstallationDomain domain)
        {
            if (!_installationDao.ExistsByExternalId(domain.ExternalId)) {
                InstallationEntity entity = _installationDao.Save(InstallationEntity.FromDomain(domain));
                return Option<InstallationDomain>.Of(entity.ToDomain());
            }
            return Option<InstallationDomain>.Empty<InstallationDomain>();
        }

        // TODO log
        public InstallationDomain Save(InstallationDomain installation)
        {
            InstallationEntity entity = _installationDao.Save(InstallationEntity.FromDomain(installation));
            return entity.ToDomain();
        }

        // TODO log
        public Option<InstallationDomain> FindById(long id) => Option<InstallationDomain>
            .Of(_installationDao.FindById(id))
            .Map(installation => installation.ToDomain());

        // TODO log
        public Option<InstallationDomain> FindByExternalId(long externalId) => Option<InstallationDomain>
            .Of(_installationDao.FindByExternalId(externalId))
            .Map(installation => installation.ToDomain());

        // TODO log
        public HashSet<InstallationDomain> FindAll()
            => _installationDao.FindAll()
                               .Select(entity => entity.ToDomain())
                               .ToHashSet();

        // TODO log
        // TODO revision
        public HashSet<InstallationDomain> FindAllByLocation(double latitude, double longitude, int radius)
            => _installationDao.FindAllWhereLocationInAndLongitudeIn(latitude - radius,
                                                                     latitude + radius,
                                                                     longitude - radius,
                                                                     longitude + radius)
                               .Select(entity => entity.ToDomain())
                               .ToHashSet();

        // TODO log
        public bool DeleteById(long id)
            => _installationDao.DeleteById(id);

        #region Factory

        public static class Factory
        {
            public static InstallationRepository Create(InstallationDao installationDao)
                => new InstallationRepository(installationDao ?? throw new ArgumentException("InstallationDao in null."));
        }

        #endregion
    }
}
