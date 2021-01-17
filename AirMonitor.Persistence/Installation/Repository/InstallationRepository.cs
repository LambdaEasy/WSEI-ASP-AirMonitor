using System;
using System.Collections.Generic;
using AirMonitor.Core.Installation;
using AirMonitor.Util.Flow;

namespace AirMonitor.Persistence.Installation.Repository
{
    public class InstallationRepository : IInstallationRepository
    {
        private readonly InstallationDao _dao;

        private InstallationRepository(InstallationDao dao)
        {
            this._dao = dao;
        }

        public Option<Domain.Installation.Installation> TrySave(Domain.Installation.Installation installation)
        {
            throw new System.NotImplementedException();
        }

        public Domain.Installation.Installation Save(Domain.Installation.Installation installation)
        {
            throw new System.NotImplementedException();
        }

        public Option<Domain.Installation.Installation> FindById(long id)
        {
            throw new System.NotImplementedException();
        }

        public Option<Domain.Installation.Installation> FindByExternalId(long externalId)
        {
            throw new System.NotImplementedException();
        }

        public HashSet<Domain.Installation.Installation> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public HashSet<Domain.Installation.Installation> FindAllByLocation(float latitude, float longitude, int radius)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteById(long id)
        {
            throw new System.NotImplementedException();
        }

        #region Factory

        public static class Factory
        {
            public static InstallationRepository Create(InstallationDao dao)
                => new InstallationRepository(dao ?? throw new ArgumentException("InstallationDao in null."));
        }

        #endregion
    }
}
