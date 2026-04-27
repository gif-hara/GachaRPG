using System.Collections.Generic;
using UnityEngine;

namespace GachaRPG
{
    public sealed class Gacha
    {
        public List<InstanceGachaElement> Elements { get; }

        public Gacha(int elementSize)
        {
            Elements = new List<InstanceGachaElement>();
            for (int i = 0; i < elementSize; i++)
            {
                Elements.Add(null);
            }
        }

        public void SetGachaElement(int index, InstanceGachaElement element)
        {
            if (index < 0 || index >= Elements.Count)
            {
                Debug.LogError($"Index {index} is out of range for gacha elements.");
                return;
            }
            if (Elements[index] != null)
            {
                Elements[index].GachaEquipmentIndex = -1;
            }
            Elements[index] = element;
            element.GachaEquipmentIndex = index;
        }

        public GachaResult Invoke()
        {
            var passiveSkills = new List<InstancePassiveSkill>();
            for (int i = 0; i < Elements.Count; i++)
            {
                if (Elements[i] == null)
                {
                    continue;
                }
                passiveSkills.Add(Elements[i].Lottery());
            }
            return new GachaResult(passiveSkills);
        }
    }
}
