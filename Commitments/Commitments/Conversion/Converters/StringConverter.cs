using System;
using System.IO;

namespace Commitments.Conversion.Converters
{
    public class StringConverter
    {
        public static byte[] HexStringToByteArray(string input)
        {
            var outputLength = input.Length / 2;
            var output = new byte[outputLength];
            using var sr = new StringReader(input);
            for (var i = 0; i < outputLength; i++)
            {
                output[i] = Convert.ToByte(new string(new[] {(char) sr.Read(), (char) sr.Read()}), 16);
            }
            return output;
        }
    }
}