using System;
using System.Collections.Generic;
using System.Linq;
using AirMonitor.Core.Measurement;
using AirMonitor.Persistence.Measurement.Entity;
using AirMonitor.Util.Flow;
using MeasurementDomain = AirMonitor.Domain.Measurement.Measurement;

namespace AirMonitor.Persistence.Measurement.Repository
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private readonly MeasurementDao _measurementDao;

        private MeasurementRepository(MeasurementDao measurementDao)
        {
            this._measurementDao = measurementDao;
        }

        public Option<MeasurementDomain> TrySave(MeasurementDomain domain)
            => !_measurementDao.ExistsById(domain.Id)
             ? Option<MeasurementDomain>.Of(Save(domain))
             : Option<MeasurementDomain>.Empty<MeasurementDomain>();

        public MeasurementDomain Save(MeasurementDomain domain)
            => _measurementDao.Save(MeasurementEntity.FromDomain(domain)).ToDomain();
        
        public Option<MeasurementDomain> FindById(long id) => Option<MeasurementDomain>
            .Of(_measurementDao.FindById(id))
            .Map(entity => entity.ToDomain());

        public ISet<MeasurementDomain> FindAll()
            => _measurementDao.FindAll()
                              .Select(entity => entity.ToDomain())
                              .ToHashSet();

        public bool DeleteById(long id)
            => _measurementDao.DeleteById(id);
        
        #region Factory

        public static class Factory
        {
            public static MeasurementRepository Create(MeasurementDao measurementDao)
                => new MeasurementRepository(measurementDao ?? throw new ArgumentException("MeasurementDao in null."));
        }

        #endregion
    }
}
