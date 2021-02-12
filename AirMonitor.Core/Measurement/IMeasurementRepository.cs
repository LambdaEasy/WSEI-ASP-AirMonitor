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

        ISet<MeasurementDomain> FindAll();

        bool DeleteById(long id);
    }
}
