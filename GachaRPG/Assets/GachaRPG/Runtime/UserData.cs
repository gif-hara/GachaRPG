using System.Collections.Generic;
using UnityEngine;

namespace GachaRPG
{
    public sealed class UserData
    {
        public List<Character> Characters { get; private set; } = new();

        public Gacha Gacha { get; }

        private readonly List<GachaResult> gachaResults = new();

        public List<GachaResult> GachaResults => gachaResults;

        public UserData(Gacha gacha)
        {
            Gacha = gacha;
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
