using UnityEngine;

namespace GachaRPG
{
    public sealed class UserData
    {
        public Character[] Characters { get; private set; }

        public UserData(Character[] characters)
        {
            Characters = characters;
        }
    }
}
