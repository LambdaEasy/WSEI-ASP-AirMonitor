using System;

// TODO [refactor] static
namespace AirMonitor.Client.Api
{
    public class AirlyClientFunction
    {
        #region Fields

        private const string ApiGetInstallationsPrefix = "installations/nearest";
        
        private readonly AirlyClientFunctionType _type;

        #endregion

        #region Constructors

        private AirlyClientFunction(AirlyClientFunctionType type)
        {
            _type = type;
        }

        #endregion
        
        public string ApiPath
        {
            get
            {
                switch (_type)
                {
                    case AirlyClientFunctionType.GetInstallationsNearest:
                        return ApiGetInstallationsPrefix;
                    default:
                        throw new ArgumentException($"Unsupported Airly api function={_type}");
                }
            }
        }

        #region StaticConstructors

        public static AirlyClientFunction GetInstallationsNearest => new AirlyClientFunction(AirlyClientFunctionType.GetInstallationsNearest);

        #endregion

        #region Type

        public enum AirlyClientFunctionType
        {
            GetInstallationsNearest
        }

        #endregion
    }
}
