using System;
using System.Linq;

namespace SportsLiveScoreboard.Services.RandomCodes
{
    public class DefaultCodeGenerator : IRandomCodeProvider
    {
        private readonly Random _random;
        private readonly char[] _characters;

        public DefaultCodeGenerator()
        {
            _random = new Random();
            _characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToLower().ToCharArray();
        }

        public string GenerateCode(int length)
        {
            return GenerateCode(length, _characters);
        }

        public string GenerateCode(int length, char[] characters)
        {
            return new string(Enumerable.Range(0, length)
                .Select(s => characters[_random.Next(characters.Length)]).ToArray());
        }
    }
}