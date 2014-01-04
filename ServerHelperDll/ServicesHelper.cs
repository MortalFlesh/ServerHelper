using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Security;
using System.Diagnostics;

namespace ServerHelperDll
{
    public class ServicesHelper
    {
        /// <summary>
        /// Konstruktor třídy, který vytvoří instanci pouze s názvu Služby
        /// a nastaví ostatní hodnoty na defaultní
        /// </summary>
        /// <param name="serviceName">Název služby</param>
        public ServicesHelper(string serviceName)
            : this(serviceName, _DEFAULT_TIMEOUT_MILLISECONDS)
        {
        }

        /// <summary>
        /// Konstruktor třídy, který vytvoří instanci s názvu Služby
        /// a nastaví konkrétní hodnoty
        /// </summary>
        /// <param name="serviceName">Název služby</param>
        /// <param name="timeoutMilliseconds">Časový limit, který se bude používat při práci se službou</param>
        public ServicesHelper(string serviceName, int timeoutMilliseconds)
        {
            ServiceName = serviceName;
            _service = new ServiceController(ServiceName);
            _timeoutMilliseconds = timeoutMilliseconds;
        }

        /// <summary>
        /// Spustí službu
        /// </summary>
        /// <returns></returns>
        public bool StartService()
        {
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(_timeoutMilliseconds);

                _service.Start();
                _service.WaitForStatus(ServiceControllerStatus.Running, timeout);
               
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Zastaví službu
        /// </summary>
        /// <returns></returns>
        public bool StopService()
        {
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(_timeoutMilliseconds);

                _service.Stop();
                _service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Restartuje službu (zastaví ji a znovu spustí)
        /// </summary>
        /// <returns></returns>
        public bool RestartService()
        {
            try
            {
                if (StopService())
                {
                    return StartService();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// Vrátí, zda služba běží (není zastavena)
        /// </summary>
        /// <returns></returns>
        public bool isRunning()
        {
            return !_isStopped();
        }

        /// <summary>
        /// Vrátí, zda je služba zastavena nebo se zastavuje
        /// </summary>
        /// <returns></returns>
        private bool _isStopped()
        {
            return _service.Status.Equals(ServiceControllerStatus.Stopped) || _service.Status.Equals(ServiceControllerStatus.StopPending);
        }

        /// <summary>
        /// Otevře okno pro správu služeb
        /// </summary>
        public static void ShowServicesWindow()
        {
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                UseShellExecute = false,
                FileName = "mmc",
                Arguments = "services.msc"
            };
            Process.Start(psi);
        }

        /// <summary>
        /// Název služby
        /// </summary>
        public string ServiceName { get; set; }

        public const string APPACHE2_4 = "Apache2.4";
        public const string APPACHE2_2 = "Apache2.2";

        private ServiceController _service;
        private int _timeoutMilliseconds;

        private const int _DEFAULT_TIMEOUT_MILLISECONDS = 50 * 1000;
    }
}
