using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerHelperDll.Checkers
{
    internal class VHost
    {
        /// <summary>
        /// Vrátí instanci třídy VHost, vytvořenou z obsahu souboru
        /// </summary>
        /// <param name="vHostFileContent">Obsah souboru</param>
        /// <returns></returns>
        internal static VHost FromFileContent(string[] vHostFileContent)
        {
            return new VHost(vHostFileContent);
        }

        /// <summary>
        /// Konstruktor, který vytvoří instanci z řádků souboru
        /// </summary>
        /// <param name="vHostFileContent">Řádky souboru</param>
        private VHost(string[] vHostFileContent)
        {
            _vHostFileContent = vHostFileContent;
        }

        /// <summary>
        /// Vrátí, zda již virtual host obsahuje nový web 
        /// </summary>
        /// <param name="newWeb">Instance nového webu</param>
        /// <returns></returns>
        internal bool IsAlreadyContains(Web newWeb)
        {
            string[] newWebTemplate = _generateNewWebTemplate(newWeb);
            string serverNameLine = _getServerNameLine(newWebTemplate);

            for (int i = 0; i < _vHostFileContent.Length; i++)
            {
                if (_equalLines(_vHostFileContent[i], serverNameLine))
                {
                    if (_checkAllLines(newWebTemplate, i))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Vrátí nový záznam pro virtual host
        /// </summary>
        /// <param name="newWeb">Instance nového webu</param>
        /// <returns></returns>
        private string[] _generateNewWebTemplate(Web newWeb)
        {
            return new string[] {
                "<VirtualHost *:80>",
                "\tServerAdmin webmaster@localhost",
	            string.Format("\tDocumentRoot {0}/{1}", newWeb.HtDocsPath, newWeb.Folder),
	            string.Format("\tServerName {0}", newWeb.Domain),
                "",
	            string.Format("\t<Directory \"{0}/{1}\">", newWeb.HtDocsPath, newWeb.Folder),
		        "\t\tOptions Indexes FollowSymLinks Includes ExecCGI",
		        "\t\tAllowOverride All",
		        "\t\tOrder allow,deny",
		        "\t\tAllow from all",
	            "\t</Directory>",
                "</VirtualHost>"
            };
        }

        /// <summary>
        /// Vrátí ServerName ze záznamu webu
        /// </summary>
        /// <param name="webTemplate">Záznam webu</param>
        /// <returns></returns>
        private string _getServerNameLine(string[] webTemplate)
        {
            return webTemplate[_SERVER_NAME_LINE_INDEX];
        }

        /// <summary>
        /// Porovná, zda jsou řádky stejné
        /// </summary>
        /// <param name="line1">Řádek 1</param>
        /// <param name="line2">Řádek 2</param>
        /// <returns>TRUE - řádky jsou stejné | FALSE - řádky nejsou stejné</returns>
        private bool _equalLines(string line1, string line2)
        {
            return line1.Equals(line2);
        }

        /// <summary>
        /// Porovná všechny řádky nového záznamu s pozicí ve virtual hostu
        /// </summary>
        /// <param name="newWebTemplate">Pole s řádky nového záznamu</param>
        /// <param name="i">Výchozí pozice pro ověřování - řádek se server name</param>
        /// <returns>TRUE - všechny řádky nového záznamu souhlasí | FALSE - alespoň jeden řádek je různý</returns>
        private bool _checkAllLines(string[] newWebTemplate, int i)
        {
            int vHostIterator = i - _SERVER_NAME_LINE_INDEX;
            for (int j = 0; j < newWebTemplate.Length; j++, vHostIterator++)
            {
                if (!_equalLines(_vHostFileContent[vHostIterator], newWebTemplate[j]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Přidá nový web do vHostu
        /// </summary>
        /// <param name="newWeb">Instance nového webu</param>
        internal void AddNewWeb(Web newWeb)
        {
            // zkotroluji, zda se ve vhostu již vyskytuje pomocný tag, pokud ne, přidám ho
            _addHelpTagIfItsNotThere();
            _insertNewWeb(newWeb);
        }

        /// <summary>
        /// Přidá do virtual hostu pomocný tag, je-li to nutné
        /// </summary>
        private void _addHelpTagIfItsNotThere()
        {
            // zkotroluji, zda se v hostu již vyskytuje pomocný tag, pokud ne, přidám ho
            if (!_vHostFileContent.Contains(_HOST_START_TAG) || !_vHostFileContent.Contains(_HOST_END_TAG))
            {
                string[] help = new string[]
                {
                    _V_HOST_SEPARATOR,
                    _HOST_START_TAG,
                    _V_HOST_SEPARATOR,
                    _HOST_END_TAG
                };

                _vHostFileContent = _vHostFileContent.Concat(help).ToArray();
            }
        }

        // Vloží řádky nového webu mezi řádky virtual hostu
        private void _insertNewWeb(Web newWeb)
        {
            string[] newWebTemplate = _generateNewWebTemplate(newWeb);
            string[] newVhost = new string[_vHostFileContent.Length + newWebTemplate.Length + _NEW_END_TAG_LENGTH];  // +1 je proto, ze _HOST_END_TAG se vklada novy, ale je i ve starem souboru
            int newVhostPos = 0;

            foreach (string vHostLine in _vHostFileContent)
            {
                if (_equalLines(vHostLine, _HOST_END_TAG))
                {
                    // najdu koncovy tag a vlozim na jeho misto novy web
                    for (int j = 0; j < newWebTemplate.Length; j++)
                    {
                        newVhost[newVhostPos++] = newWebTemplate[j];
                    }
                    newVhost[newVhostPos++] = _V_HOST_SEPARATOR;
                    newVhost[newVhostPos++] = _HOST_END_TAG;
                }
                else newVhost[newVhostPos++] = vHostLine;    // pokud neni nalezen endTag, kopiruju z vhostu
            }
            _vHostFileContent = newVhost;
        }

        /// <summary>
        /// Vrátí obsah virtual hostu
        /// </summary>
        /// <returns></returns>
        internal string[] GetVHostFileContent()
        {
            return _vHostFileContent;
        }

        /// <summary>
        /// Obsah souboru virtual hostu
        /// </summary>
        private string[] _vHostFileContent;

        private const int _SERVER_NAME_LINE_INDEX = 3;
        private const string _HOST_START_TAG = "## netdevelo";
        private const string _HOST_END_TAG = "## /netdevelo";
        private const string _V_HOST_SEPARATOR = "";
        private const int _NEW_END_TAG_LENGTH = 1;
    }
}
