using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerHelperDll.Checkers
{
    internal class Host
    {
        /// <summary>
        /// Vytvoří novou instanci třídy pro práci s hostem z obsahu souboru
        /// </summary>
        /// <param name="hostContent">Obsah host souboru</param>
        /// <returns></returns>
        internal static Host FromFileContent(string[] hostContent)
        {
            return new Host(hostContent);
        }

        /// <summary>
        /// Konstruktor, který vytvoří instanci z načtenýc řádků
        /// </summary>
        /// <param name="hostContent">Načtené řádky</param>
        private Host(string[] hostContent)
        {
            _hostContent = hostContent;
        }        

        /// <summary>
        /// Vrátí, zda se v hostu již vyskytuje doména
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        internal bool IsAlreadyContains(string domain)
        {
            string newDomainLine = _generateNewDomainLine(domain);
            return _isNewDomainAlreadyInHost(newDomainLine);
        }

        /// <summary>
        /// Přidá do hostu novou doménu
        /// </summary>
        /// <param name="domain">Nová doména</param>
        internal void AddNewDomain(string domain)
        {
            // zkotroluji, zda se v hostu již vyskytuje pomocný tag, pokud ne, přidám ho
            _addHelpTagIfItsNotThere();
            _insertNewDomain(domain);
        }

        /// <summary>
        /// Vloží nový řádek s doménou do hostu
        /// </summary>
        /// <param name="newDomainLine">Nová doména</param>
        private void _insertNewDomain(string domain)
        {
            string newDomainLine = _generateNewDomainLine(domain);
            string[] newHost = new string[_hostContent.Length + _NEW_END_TAG_LENGTH];
            int newHostPos = 0;

            // celé pole puvodního hostu zkopíruju a přidám novou doménu
            foreach (string hostLine in _hostContent)
            {
                if (hostLine.Equals(_HOST_END_TAG))
                {
                    // zkontroluji jestli někdo nesmazal pred koncovym tagem mezeru (prazdny radek)
                    if (newHost[newHostPos - 1] == _SEPARATOR)
                    {
                        newHost[newHostPos - 1] = newDomainLine;  // prepisu prazdny radek
                        newHost[newHostPos++] = _SEPARATOR;
                    }
                    else
                    {
                        newHost[newHostPos++] = newDomainLine;
                    }
                    newHost[newHostPos++] = _HOST_END_TAG;
                }
                else newHost[newHostPos++] = hostLine;
            }
            _hostContent = newHost;
        }

        /// <summary>
        /// Přidá pomocný tag do hostu, pokud tam již není
        /// </summary>
        private void _addHelpTagIfItsNotThere()
        {
            // zkotroluji, zda se v hostu již vyskytuje pomocný tag, pokud ne, přidám ho
            if (!_hostContent.Contains(_HOST_START_TAG) || !_hostContent.Contains(_HOST_END_TAG))
            {
                string[] help = new string[] {
                        _SEPARATOR,
                        _HOST_START_TAG,
                        _SEPARATOR,
                        _SEPARATOR,
                        _HOST_END_TAG
                    };

                _hostContent = _hostContent.Concat(help).ToArray();
            }
        }

        /// <summary>
        /// Vrátí, zda se již řádek s novou doménou v hostu nenachází
        /// </summary>
        /// <param name="newDomainLine">Řádek nové domény</param>
        /// <returns></returns>
        private bool _isNewDomainAlreadyInHost(string newDomainLine)
        {
            return _hostContent.Contains(newDomainLine);
        }

        /// <summary>
        /// Vygeneruje řádek nové domény
        /// </summary>
        /// <param name="domain">Název domény</param>
        /// <returns></returns>
        private string _generateNewDomainLine(string domain)
        {
            return string.Format("127.0.0.1\t{0}", domain);
        }

        /// <summary>
        /// Vrátí obsah souboru host
        /// </summary>
        /// <returns></returns>
        internal string[] GetHostContent()
        {
            return _hostContent;
        }

        /// <summary>
        /// Obsah host souboru
        /// </summary>
        private string[] _hostContent;

        private const string _HOST_START_TAG = "## netdevelo";
        private const string _HOST_END_TAG = "## /netdevelo";
        private const string _SEPARATOR = "";
        private const int _NEW_END_TAG_LENGTH = 1;
    }
}
