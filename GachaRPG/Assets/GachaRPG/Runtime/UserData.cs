using System.Collections.Generic;
using UnityEngine;

namespace GachaRPG
{
    public sealed class UserData
    {
        public List<Character> Characters { get; private set; } = new();

        private readonly List<GachaResult> gachaResults = new();

        public List<GachaResult> GachaResults => gachaResults;

        public UserData()
        {
        }

        public void AddCharacter(Character character)
        {
            Characters.Add(character);
        }

        public void AddGachaResult(GachaResult result)
        {
            gachaResults.Add(result);
        }
    }
}
