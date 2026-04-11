using System.Collections.Generic;
using UnityEngine;

namespace GachaRPG
{
    public sealed class Gacha
    {
        private readonly GachaElement[] elements;

        public Gacha(int elementSize)
        {
            elements = new GachaElement[elementSize];
        }

        public void SetGachaElement(int index, GachaElement element)
        {
            if (index < 0 || index >= elements.Length)
            {
                Debug.LogError($"Index {index} is out of range for gacha elements.");
                return;
            }
            elements[index] = element;
        }

        public GachaResult Invoke()
        {
            var passiveSkills = new List<PassiveSkill>();
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] == null)
                {
                    continue;
                }
                passiveSkills.Add(elements[i].Lottery());
            }
            return new GachaResult(passiveSkills.ToArray());
        }
    }
}
