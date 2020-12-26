using System.Collections.Generic;
using AirMonitor.Core.Util.Flow;
using InstallationDomain = AirMonitor.Domain.Installation.Installation;

namespace AirMonitor.Core.Installation
{
    public interface IInstallationRepository
    {
        /// <summary>
        /// Attempts to save Installation. If installation of given technical id already exists this action will be
        /// omitted and Option.Empty will be returned instead.
        /// </summary>
        /// <param name="installation">Installation data attempted to be saved</param>
        /// <returns>Option of saved Installation or empty Option</returns>
        Option<InstallationDomain> TrySave(InstallationDomain installation);

        /// <summary>
        /// Saves Installation data. If installation of given technical Id already exists will overwrite it.
        /// </summary>
        /// <param name="installation"></param>
        /// <returns>Saved Installation</returns>
        InstallationDomain Save(InstallationDomain installation);

        /// <summary>
        /// Attempts to find an Installation by its technical uid, if not found will return empty option.
        /// </summary>
        /// <param name="id">Installation technical id</param>
        /// <returns>Option containing installation with given id, otherwise an empty Option</returns>
        Option<InstallationDomain> FindById(long id);

        /// <summary>
        /// Attempts to find an Installation by its external uid, if not found will return empty option.
        /// </summary>
        /// <param name="externalId"></param>
        /// <returns>Option containing installation with given id, otherwise an empty Option</returns>
        Option<InstallationDomain> FindByExternalId(long externalId);

        /// <summary>
        /// Returns all installations known.
        /// </summary>
        /// <returns>Set of installations</returns>
        HashSet<InstallationDomain> FindAll();

        /// <summary>
        /// Returns all known localizations nearby given coordinates.
        /// </summary>
        /// <param name="latitude">Latitude of coordinates to search nearby</param>
        /// <param name="longitude">Longitude of coordinates to search nearby</param>
        /// <param name="radius">
        /// Radius (in km) of circle around given coordinates in which installations will be included in result set
        /// </param>
        /// <returns>Set of installations</returns>
        HashSet<InstallationDomain> FindAllByLocation(float latitude, float longitude, int radius);

        /// <summary>
        /// Deletes Installation data by given technical Id.
        /// </summary>
        /// <param name="id">Installation technical id</param>
        /// <returns>True if Installation was deleted</returns>
        bool DeleteById(long id);
    }
}
