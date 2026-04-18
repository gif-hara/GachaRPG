using System.Collections.Generic;
using UnityEngine;

namespace GachaRPG
{
    public sealed class Gacha
    {
        private readonly List<InstanceGachaElement> elements;

        public Gacha(int elementSize)
        {
            elements = new List<InstanceGachaElement>();
            for (int i = 0; i < elementSize; i++)
            {
                elements.Add(null);
            }
        }

        public void SetGachaElement(int index, InstanceGachaElement element)
        {
            if (index < 0 || index >= elements.Count)
            {
                Debug.LogError($"Index {index} is out of range for gacha elements.");
                return;
            }
            elements[index] = element;
        }

        public GachaResult Invoke()
        {
            var passiveSkills = new List<InstancePassiveSkill>();
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i] == null)
                {
                    continue;
                }
                passiveSkills.Add(elements[i].Lottery());
            }
            return new GachaResult(passiveSkills);
        }
    }
}
