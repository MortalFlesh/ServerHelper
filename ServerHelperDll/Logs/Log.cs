using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ServerHelperDll.Logs
{
    internal class Log
    {
        /// <summary>
        /// Vytvoří instanci Logu dle názvu souboru
        /// </summary>
        /// <param name="fileName">Název souboru</param>
        /// <returns></returns>
        internal static Log CreateFromFileName(string fileName)
        {
            return new Log(fileName);
        }

        /// <summary>
        /// Konstruktor, který vytvoří instanci dle názvu souboru
        /// </summary>
        /// <param name="fileName">Název souboru</param>
        public Log(string fileName)
        {
            if (_hasExtension(fileName))
            {
                _logFileName = fileName;
            }
            else
            {
                _logFileName = _addExtension(fileName);
            }

            _createFileIfNotExists();
        }

        /// <summary>
        /// Vrátí, zda název souboru obsahuje koncovku pro log
        /// </summary>
        /// <param name="fileName">Název souboru</param>
        /// <returns></returns>
        private bool _hasExtension(string fileName)
        {
            return fileName.Contains(_LOG_EXTENSION);
        }

        /// <summary>
        /// Přidá za název souboru koncovku pro log
        /// </summary>
        /// <param name="fileName">Název souboru</param>
        /// <returns></returns>
        private string _addExtension(string fileName)
        {
            return string.Format("{0}{1}", fileName, _LOG_EXTENSION);
        }

        /// <summary>
        /// Vytvoří nový soubor pro log, pokud neexistuje
        /// </summary>
        private void _createFileIfNotExists()
        {
            if (!File.Exists(_logFileName))
            {
                File.Create(_logFileName).Close();
            }
        }

        /// <summary>
        /// Zapíše zprávu na konec logu
        /// </summary>
        /// <param name="message">Zpráva</param>
        internal void Write(string message)
        {
            _appendMessage(message);
        }

        /// <summary>
        /// Přidá zprávu na konec logu - ke zprávě se dopíše čas
        /// </summary>
        /// <param name="message">Zpráva</param>
        private void _appendMessage(string message)
        {
            var stream = File.AppendText(_logFileName);
            stream.WriteLine(_addTimeToMessage(message));
            stream.Close();
        }

        /// <summary>
        /// Vrátí nový řádek do logu, který obsahuje aktuální čas a zprávu
        /// </summary>
        /// <param name="message">Zpráva</param>
        /// <returns></returns>
        private string _addTimeToMessage(string message)
        {
            return string.Format("{0}\t{1}", _getActualDateTime(), message);
        }

        /// <summary>
        /// Vrátí aktuální čas
        /// </summary>
        /// <returns></returns>
        private string _getActualDateTime()
        {
            return DateTime.Now.ToLocalTime().ToString();
        }

        private string _logFileName;
        
        private const string _LOG_EXTENSION = ".log";
    }
}
