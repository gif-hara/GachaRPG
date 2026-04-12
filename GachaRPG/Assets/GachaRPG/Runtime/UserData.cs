using System.Collections.Generic;

namespace GachaRPG
{
    public sealed class UserData
    {
        public List<Character> Characters { get; private set; } = new();

        public Gacha Gacha { get; }

        public List<GachaResult> GachaResults { get; } = new();

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
            GachaResults.Add(result);
        }
    }
}
