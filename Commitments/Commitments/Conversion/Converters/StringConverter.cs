using System;
using System.IO;

namespace Commitments.Conversion.Converters
{
    public class StringConverter
    {
        public static byte[] StringToByteArray(string input, int fromBase)
        {
            var outputLength = input.Length / 2;
            var output = new byte[outputLength];
            using var sr = new StringReader(input);
            for (var i = 0; i < outputLength; i++)
            {
                output[i] = Convert.ToByte(new string(new[] {(char) sr.Read(), (char) sr.Read()}), fromBase);
            }
            return output;
        }
    }
}