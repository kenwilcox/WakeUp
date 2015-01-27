using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace WakeUp
{
  /// <summary>
  /// Simple program that just hits a bunch or pages.
  /// </summary>
  class Program
  {
    static WebClient _client;

    static void Fecth(string url, string fileName)
    {
      if (_client == null) _client = new WebClient();
      Directory.CreateDirectory(Path.GetDirectoryName(fileName));
      
      try
      {
        Uri uri = new Uri(url);
        _client.DownloadFile(uri, fileName);
      }
      catch { } // I don't care...
    }

    static void DumpText(string text, string filename)
    {
      using (StreamWriter outfile = new StreamWriter(filename))
      {
        outfile.Write(text);
        outfile.Flush();
      }
    }
    
    static void Main(string[] args)
    {
      // Just add what you want here...
      Dictionary<string, string> keepAlive = new Dictionary<string, string>() {
        {@"C:\Temp\WakeUp\api.canyonco.org.html", "http://api.canyonco.org/"},
        {@"C:\Temp\WakeUp\sheriff-beta.html", "http://api.canyonco.org/Sheriff-Beta/"},
        {@"C:\Temp\WakeUp\kdev.canyonco.org.html", "http://kdev.canyonco.org/"},
        {@"C:\Temp\WakeUp\ktest.canyonco.org.html", "http://ktest.canyonco.org/"},
        {@"C:\Temp\WakeUp\kprod2.canyonco.org.html", "http://kprod2.canyonco.org/"},
      };

      foreach (KeyValuePair<string, string> kvp in keepAlive)
      {
        Fecth(kvp.Value, kvp.Key);
      }
    }
  }
}
