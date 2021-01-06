using System.Collections.Generic;
using AirMonitor.Core.Installation.Command;
using AirMonitor.Domain.Installation.Dto;
using AirMonitor.Util.Flow;

namespace AirMonitor.Core.Installation
{
    public interface IInstallationFacade
    {
        /// <summary>
        /// Creates installation. Saves data in database and return application object.
        /// </summary>
        /// <param name="command">Create command with data necessary to create new Installation.</param>
        /// <returns>Created installation or error with occured.</returns>
        Either<InstallationError, InstallationDto> CreateInstallation(InstallationCreateCommand command);
        
        /// <summary>
        /// Searches stored Installations by technical uid. 
        /// </summary>
        /// <param name="id">Technical id of Installation</param>
        /// <returns>Found installation or error with occured</returns>
        Either<InstallationError, InstallationDto> GetById(long id);
        
        /// <summary>
        /// Searches stored Installations by external uid. 
        /// </summary>
        /// <param name="id">External id of Installation</param>
        /// <returns>Found installation or error with occured</returns>
        Either<InstallationError, InstallationDto> GetByExternalId(long id);
        
        /// <summary>
        /// Returns all stored installations.
        /// </summary>
        /// <returns>Set of Installations</returns>
        HashSet<InstallationDto> GetAll();
        
        /// <summary>
        /// Returns all installations nearby given coordinates.
        /// </summary>
        /// <param name="command">Command containing all data necessary for search query.</param>
        /// <returns>Set of Installations</returns>
        HashSet<InstallationDto> GetAllNearby(InstallationGetAllNearbyCommand command);
        
        /// <summary>
        /// Updates stored Installation data and returns new updated Installation.
        /// </summary>
        /// <param name="command">Command containing data necessary for update.</param>
        /// <returns>Updated Installation or error which occured</returns>
        Either<InstallationError, InstallationDto> Update(InstallationUpdateCommand command);
        
        /// <summary>
        /// Deletes Installation of given technical Id. Returns operation result.
        /// </summary>
        /// <param name="command">Command with data necessary to delete Installation.</param>
        /// <returns>True if Installation was deleted.</returns>
        bool Delete(InstallationDeleteCommand command);
    }
}
