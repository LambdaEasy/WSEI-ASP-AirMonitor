using System.Collections.Generic;
using AirMonitor.Util.Flow;
using MeasurementDomain = AirMonitor.Domain.Measurement.Measurement;

namespace AirMonitor.Core.Measurement
{
    public interface IMeasurementRepository
    {
        Option<MeasurementDomain> TrySave(MeasurementDomain domain);

        MeasurementDomain Save(MeasurementDomain domain);

        Option<MeasurementDomain> FindById(long id);

        Option<MeasurementDomain> FindByExternalId(long externalId);

        ISet<MeasurementDomain> FindAll();

        ISet<MeasurementDomain> FindAllOutdated();

        bool IsOutdatedByInstallationExternalId(long installationExternalId);

        bool DeleteById(long id);
    }
}
