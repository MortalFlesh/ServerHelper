using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerHelperDll.Checkers
{
    internal class Web
    {
        /// <summary>
        /// Konstruktor webu
        /// </summary>
        /// <param name="domain">Doména</param>
        /// <param name="htDocsPath">Cesta k htDocs</param>
        /// <param name="folder">Složka webu</param>
        internal Web(string domain, string htDocsPath, string folder)
        {
            Domain = domain;
            HtDocsPath = htDocsPath;
            Folder = folder;
        }
        
        internal string Domain { get; set; }

        internal string Folder { get; set; }

        internal string HtDocsPath { get; set; }
    }
}
