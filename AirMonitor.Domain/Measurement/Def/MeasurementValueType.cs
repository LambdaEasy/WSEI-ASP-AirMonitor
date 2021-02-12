using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace AirMonitor.Domain.Measurement
{
    public enum MeasurementValueTypeName
    {
        PM1,
        PM10,
        PM25,
        Temperature,
        Humidity,
        Pressure,
        WindSpeed,
        WindBearing,
        NO2,
        O3,
        SO2,
        CO,
        H2S,
        NO
    }

    public class MeasurementValueType : IEquatable<MeasurementValueType>
    {
        #region AssosiationEnum

        public static MeasurementValueType GetForName(MeasurementValueTypeName name)
            => EnumMap.First(type => type.Name == name) ?? throw new ArgumentException("Invalid MeasurementValueType name.");

        public static MeasurementValueType PM1 = new MeasurementValueType(MeasurementValueTypeName.PM1, "PM1", "µg/m³");
        public static MeasurementValueType PM10 = new MeasurementValueType(MeasurementValueTypeName.PM10, "PM10", "µg/m³");
        public static MeasurementValueType PM25 = new MeasurementValueType(MeasurementValueTypeName.PM25, "PM25", "µg/m³");
        public static MeasurementValueType Temperature = new MeasurementValueType(MeasurementValueTypeName.Temperature, "Temperature", "°C");
        public static MeasurementValueType Humidity = new MeasurementValueType(MeasurementValueTypeName.Humidity, "Humidity", "%");
        public static MeasurementValueType Pressure = new MeasurementValueType(MeasurementValueTypeName.Pressure, "Pressure", "hPa");
        public static MeasurementValueType WindSpeed = new MeasurementValueType(MeasurementValueTypeName.WindSpeed, "Wind speed", "km/h");
        public static MeasurementValueType WindBearing = new MeasurementValueType(MeasurementValueTypeName.WindBearing, "Wind bearing", "°");
        public static MeasurementValueType NO2 = new MeasurementValueType(MeasurementValueTypeName.NO2, "NO₂", "µg/m³");
        public static MeasurementValueType O3 = new MeasurementValueType(MeasurementValueTypeName.O3, "O₃", "µg/m³");
        public static MeasurementValueType SO2 = new MeasurementValueType(MeasurementValueTypeName.SO2, "SO₂", "µg/m³");
        public static MeasurementValueType CO = new MeasurementValueType(MeasurementValueTypeName.CO, "CO", "µg/m³");
        public static MeasurementValueType H2S = new MeasurementValueType(MeasurementValueTypeName.H2S, "H₂S", "µg/m³");
        public static MeasurementValueType NO = new MeasurementValueType(MeasurementValueTypeName.NO, "NO", "µg/m³");
        
        public static ISet<MeasurementValueType> EnumMap = new HashSet<MeasurementValueType>()
        {
            PM1,
            PM10,
            PM25,
            Temperature,
            Humidity,
            Pressure,
            WindSpeed,
            WindBearing,
            NO2,
            O3,
            SO2,
            SO2,
            CO,
            H2S,
            NO
        };

        public static void Validate()
        {
            if (Enum.GetValues(typeof(MeasurementValueTypeName)).Length != EnumMap.Count)
            {
                throw new InvalidEnumArgumentException("Not all MeasurementValueTypeName are registered");
            }
        }

        #endregion
    
        #region Fields

        public MeasurementValueTypeName Name => _name;
        public string Label => _label;
        public string Unit => _unit;

        private readonly MeasurementValueTypeName _name;
        private readonly string _label;
        private readonly string _unit;

        #endregion

        #region Constructor

        private MeasurementValueType(MeasurementValueTypeName name,
                                     string label,
                                     string unit)
        {
            this._name = name;
            this._label = label;
            this._unit = unit;
        }

        #endregion

        #region HashCode&Equals

        public bool Equals(MeasurementValueType other)
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
                && _label == other._label
                && _unit == other._unit;
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
            return Equals((MeasurementValueType) obj);
        }

        public override int GetHashCode()
            => HashCode.Combine((int) _name, _label, _unit);

        #endregion

        public override string ToString()
            => $"MeasurementValueType(name={_name}, label={_label}, unit={_unit})";
    }
}
