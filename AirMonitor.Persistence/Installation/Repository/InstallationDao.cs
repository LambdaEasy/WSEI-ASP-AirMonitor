using System.Collections.Generic;
using AirMonitor.Persistence.Installation.Entity;

namespace AirMonitor.Persistence.Installation.Repository
{
    public class InstallationDao
    {

        public bool ExistsByExternalId(long? id)
        {
            throw new System.NotImplementedException();
        }

        public InstallationEntity Save(InstallationEntity installation)
        {
            throw new System.NotImplementedException();
        }

        public InstallationEntity FindById(long id)
        {
            throw new System.NotImplementedException();
        }

        public InstallationEntity FindByExternalId(long externalId)
        {
            throw new System.NotImplementedException();
        }

        public HashSet<InstallationEntity> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public HashSet<InstallationEntity> FindAllWhereLocationInAndLongitudeIn(float minLatitude,
                                                                                float maxLatitude,
                                                                                float minLongitude,
                                                                                float maxLongitude)
        {
            throw new System.NotImplementedException(); 
        }

        public bool DeleteById(long id)
        {
            throw new System.NotImplementedException(); 
        }
    }
}
