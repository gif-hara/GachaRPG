using System;
using HK;
using UnityEngine;

namespace GachaRPG
{
    [CreateAssetMenu(fileName = "GachaElement", menuName = "GachaRPG/Gacha Element")]
    public class GachaElement : ScriptableObject
    {
        [field: SerializeField]
        public string ElementName { get; private set; }

        [SerializeField]
        private Element[] elements;

        public PassiveSkill Lottery() => elements.Lottery(x => x.Weight).PassiveSkill;

        public Element[] Elements => elements;

        [Serializable]
        public sealed class Element
        {
            [field: SerializeField]
            public PassiveSkill PassiveSkill { get; private set; }

            [field: SerializeField]
            public int Weight { get; private set; }
        }

        [Serializable]
        public sealed class DictionaryList : DictionaryList<string, GachaElement>
        {
            public DictionaryList() : base(element => element.name)
            {
            }
        }
    }
}
