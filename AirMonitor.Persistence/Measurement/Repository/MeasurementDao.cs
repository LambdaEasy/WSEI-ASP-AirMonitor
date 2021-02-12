using System.Collections.Generic;
using System.Linq;
using AirMonitor.Persistence.Measurement.Entity;
using Microsoft.EntityFrameworkCore;

namespace AirMonitor.Persistence.Measurement.Repository
{
    public class MeasurementDao
    {
        #region Fields

        private readonly AirMonitorDbContext _db;

        #endregion

        #region Constructors

        private MeasurementDao(AirMonitorDbContext db)
        {
            this._db = db;
        }

        #endregion

        public MeasurementEntity Save(MeasurementEntity measurement)
        {
            _db.Measurements.Add(measurement);
            _db.SaveChanges();
            return measurement;
        }

        public ISet<MeasurementEntity> FindAll()
            => _db.Measurements.Include(entity => entity.Indexes)
                               .Include(entity => entity.Standards)
                               .Include(entity => entity.Values)
                               .ToHashSet();
    }
}
