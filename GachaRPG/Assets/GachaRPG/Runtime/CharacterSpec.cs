using System;
using UnityEngine;

namespace GachaRPG
{
    [Serializable]
    public struct CharacterSpec
    {
        public string Name;

        public int HitPoint;

        public int PhysicalAttack;

        public int MagicAttack;

        public int PhysicalDefense;

        public int MagicDefense;

        public int Speed;
    }
}
