using System;
using System.Collections.Generic;
using System.Linq;
using AirMonitor.Domain.Measurement;
using MeasurementDomain = AirMonitor.Domain.Measurement.Measurement;

namespace AirMonitor.Core.Measurement.Command
{
    public readonly struct MeasurementCreateCommand : IEquatable<MeasurementCreateCommand>
    {
        #region Fields

        public long ExternalId => _installationExternalId;

        private readonly long _installationExternalId;
        private readonly DateTimeOffset _fromDateTime;
        private readonly DateTimeOffset _tillDateTime;
        private readonly ISet<Value> _values;
        private readonly ISet<Index> _indexes;
        private readonly ISet<Standard> _standards;

        #endregion

        #region Constructors

        private MeasurementCreateCommand(long installationExternalId,
                                         DateTimeOffset fromDateTime,
                                         DateTimeOffset tillDateTime,
                                         ISet<Value> values,
                                         ISet<Index> indexes,
                                         ISet<Standard> standards)
        {
            _installationExternalId = installationExternalId;
            _fromDateTime = fromDateTime;
            _tillDateTime = tillDateTime;
            _values = values;
            _indexes = indexes;
            _standards = standards;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(MeasurementCreateCommand other)
            => _installationExternalId == other._installationExternalId
            && _fromDateTime.Equals(other._fromDateTime)
            && _tillDateTime.Equals(other._tillDateTime)
            && Equals(_values, other._values)
            && Equals(_indexes, other._indexes)
            && Equals(_standards, other._standards);

        public override bool Equals(object obj)
            => obj is MeasurementCreateCommand other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(_installationExternalId, _fromDateTime, _tillDateTime, _values, _indexes, _standards);

        #endregion

        public override string ToString()
            => $"{GetType().Name}(" +
                   $"installationExternalId={_installationExternalId}, " +
                   $"fromDateTime={_fromDateTime}, " +
                   $"tillDateTime={_tillDateTime}, " +
                   $"values={_values}, " +
                   $"indexes={_indexes}, " +
                   $"standards={_standards}" +
               ")";
        
        public MeasurementDomain ToDomain()
            => MeasurementDomain.Create(_installationExternalId,
                                        _fromDateTime,
                                        _tillDateTime,
                                        Value.ToDomain(_values),
                                        Index.ToDomain(_indexes),
                                        Standard.ToDomain(_standards));

        #region StaticConstructors

        public static MeasurementCreateCommand Create(long installationExternalId,
                                                      DateTimeOffset fromDateTime,
                                                      DateTimeOffset tillDateTime,
                                                      ISet<Value> values,
                                                      ISet<Index> indexes,
                                                      ISet<Standard> standards)
            => new MeasurementCreateCommand(installationExternalId,
                                            fromDateTime,
                                            tillDateTime,
                                            values,
                                            indexes,
                                            standards);

        #endregion
    }
    
    #region Value

    public readonly struct Value : IEquatable<Value>
    {
        #region Fields

        private readonly MeasurementValueTypeName _typeName;
        private readonly double _value;

        #endregion

        #region Constructors

        private Value(MeasurementValueTypeName typeName, double value)
        {
            _typeName = typeName;
            _value = value;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(Value other)
            => _typeName == other._typeName && _value.Equals(other._value);

        public override bool Equals(object obj)
            => obj is Value other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine((int) _typeName, _value);

        #endregion

        public override string ToString()
            => $"{GetType().Name}(typeName={_typeName}, value={_value})";
        
        public MeasurementValue ToDomain()
            => MeasurementValue.Create(_typeName, _value);

        #region StaticConstructors

        public static Value Create(MeasurementValueTypeName typeName, double value)
            => new Value(typeName, value);


        public static ISet<MeasurementValue> ToDomain(ISet<Value> commands)
            => commands.Select(command => command.ToDomain()).ToHashSet();

        #endregion
    }

    #endregion

    #region Index

    public readonly struct Index : IEquatable<Index>
    {
        #region Fields

        private readonly MeasurementIndexName _name;
        private readonly double _value;
        private readonly MeasurementIndexLevel _level;
        private readonly string _description;
        private readonly string _advice;
        private readonly string _color;

        #endregion

        #region Constructors

        private Index(MeasurementIndexName name,
                      double value,
                      MeasurementIndexLevel level,
                      string description,
                      string advice,
                      string color)
        {
            _name = name;
            _value = value;
            _level = level;
            _description = description;
            _advice = advice;
            _color = color;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(Index other)
            => _name == other._name
            && _value.Equals(other._value)
            && _level == other._level
            && _description == other._description
            && _advice == other._advice
            && _color == other._color;

        public override bool Equals(object obj)
            => obj is Index other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine((int) _name, _value, (int) _level, _description, _advice, _color);

        #endregion

        public override string ToString()
            => $"{GetType().Name}(" +
                   $"name={_name}, " +
                   $"value={_value}, " +
                   $"level={_level}, " +
                   $"description={_description}, " +
                   $"advice={_advice}, " +
                   $"color={_color}" +
               ")";

        public MeasurementIndex ToDomain()
            => MeasurementIndex.Create(_name, _value, _level, _description, _advice, _color);

        #region StaticConstructors

        public static Index Create(MeasurementIndexName name,
                                   double value,
                                   MeasurementIndexLevel level,
                                   string description,
                                   string advice,
                                   string color)
            => new Index(name, value, level, description, advice, color);

        public static ISet<MeasurementIndex> ToDomain(ISet<Index> commands)
            => commands.Select(command => command.ToDomain()).ToHashSet();

        #endregion
    }

    #endregion

    #region Standard

    public readonly struct Standard : IEquatable<Standard>
    {
        #region Fields

        private readonly string _name;
        private readonly MeasurementValueTypeName _pollutant;
        private readonly double _limit;
        private readonly double _percent;
        private readonly string _averaging;

        #endregion

        #region Constructors

        private Standard(string name,
                         MeasurementValueTypeName pollutant,
                         double limit,
                         double percent,
                         string averaging)
        {
            _name = name;
            _pollutant = pollutant;
            _limit = limit;
            _percent = percent;
            _averaging = averaging;
        }

        #endregion

        #region Equals&HashCode

        public bool Equals(Standard other)
            => _name == other._name
            && Equals(_pollutant, other._pollutant)
            && _limit.Equals(other._limit)
            && _percent.Equals(other._percent)
            && _averaging == other._averaging;

        public override bool Equals(object obj)
            => obj is Standard other && Equals(other);

        public override int GetHashCode()
            => HashCode.Combine(_name, _pollutant, _limit, _percent, _averaging);

        #endregion

        public override string ToString()
            => $"{GetType().Name}(" +
                   $"name={_name}, " +
                   $"pollutant={_pollutant}, " +
                   $"limit={_limit}, " +
                   $"percent={_percent}, " +
                   $"averaging={_averaging}" +
               ")";
        
        public MeasurementStandard ToDomain()
            => MeasurementStandard.Create(_name, _pollutant, _limit, _percent, _averaging);

        #region StaticConstructors

        public static Standard Create(string name,
                                      MeasurementValueTypeName pollutant,
                                      double limit,
                                      double percent,
                                      string averaging)
            => new Standard(name, pollutant, limit, percent, averaging);

        public static ISet<MeasurementStandard> ToDomain(ISet<Standard> commands)
            => commands.Select(command => command.ToDomain()).ToHashSet();

        #endregion
    }

    #endregion
}
