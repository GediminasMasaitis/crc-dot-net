using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Crc.Demo
{
    class KnownCrcCheckRunner
    {
        private IList<CrcParameters> LoadParameters(string path)
        {
            var parameters = new List<CrcParameters>();
            var lines = File.ReadAllLines(path);
            var regex = new Regex(@"width=([^ ]+) poly=([^ ]+) init=([^ ]+) refin=([^ ]+) refout=([^ ]+) xorout=([^ ]+) check=([^ ]+) residue=([^ ]+) name=""(.+)""", RegexOptions.Compiled);
            foreach (var line in lines)
            {
                var correctedLine = line.Replace("0x", "");
                var match = regex.Match(correctedLine);
                var size = byte.Parse(match.Groups[1].Value);
                var poly = ulong.Parse(match.Groups[2].Value, NumberStyles.HexNumber);
                var init = ulong.Parse(match.Groups[3].Value, NumberStyles.HexNumber);
                var refin = bool.Parse(match.Groups[4].Value);
                var refout = bool.Parse(match.Groups[5].Value);
                var xorout = ulong.Parse(match.Groups[6].Value, NumberStyles.HexNumber);
                var check = ulong.Parse(match.Groups[7].Value, NumberStyles.HexNumber);
                var parameter = new CrcParameters(size, poly, init, xorout, refin, refout, check);
                parameters.Add(parameter);
            }
            return parameters;
        }

        public void RunChecks()
        {
            var path = "allcrcs.txt";
            var parameters = LoadParameters(path);
            foreach (var parameter in parameters)
            {
                var crc = new CrcBase(parameter);
            }
        }
    }
}

