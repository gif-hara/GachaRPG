using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
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

        public GachaResult Invoke(CancellationToken cancellationToken)
        {
            var passiveSkills = new List<InstancePassiveSkill>();
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] == null)
                {
                    continue;
                }
                passiveSkills.Add(new InstancePassiveSkill(elements[i].Lottery().name, 0));
            }
            return new GachaResult(passiveSkills);
        }
    }
}
