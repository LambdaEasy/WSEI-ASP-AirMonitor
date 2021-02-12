using System;
using System.Collections.Generic;
using System.Linq;

namespace AirMonitor.Domain.Measurement.Dto
{
    public class MeasurementIndexDto : IEquatable<MeasurementIndexDto>
    {
        #region Fields

        public MeasurementIndexName Name => _name;
        public double Value => _value;
        public MeasurementIndexLevel Level => _level;
        public string Description => _description;
        public string Advice => _advice;
        public string Color => _color;

        private readonly MeasurementIndexName _name;
        private readonly double _value;
        private readonly MeasurementIndexLevel _level;
        private readonly string _description;
        private readonly string _advice;
        private readonly string _color;
        
        #endregion

        #region Constructors

        private MeasurementIndexDto(MeasurementIndexName name,
                                    double value,
                                    MeasurementIndexLevel level,
                                    string description,
                                    string advice,
                                    string color)
        {
            this._name = name;
            this._value = value;
            this._level = level;
            this._description = description;
            this._advice = advice;
            this._color = color;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(MeasurementIndexDto other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return _name == other._name
                && _value.Equals(other._value)
                && _level == other._level
                && _description == other._description
                && _advice == other._advice
                && _color == other._color;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((MeasurementIndexDto) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine((int) _name, _value, (int) _level, _description, _advice, _color);

        #endregion

        public override string ToString()
            => $"{GetType().Name}(" + 
                   $"name={Name}, " +
                   $"value={Value}, " +
                   $"level={Level}, " +
                   $"description={Description}, " +
                   $"advice={Advice}, " +
                   $"color={Color}" +
               ")";

        #region StaticConstructors

        public static MeasurementIndexDto FromDomain(MeasurementIndex domain)
            => new MeasurementIndexDto(domain.Name,
                                       domain.Value,
                                       domain.Level,
                                       domain.Description,
                                       domain.Advice,
                                       domain.Color);

        public static ISet<MeasurementIndexDto> FromDomain(IEnumerable<MeasurementIndex> domain)
            => domain.Select(FromDomain).ToHashSet();
        
        #endregion
    }
}