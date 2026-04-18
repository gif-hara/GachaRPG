using System;
using HK;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GachaRPG
{
    [CreateAssetMenu(fileName = "GachaElement", menuName = "GachaRPG/Gacha Element")]
    public class GachaElement : ScriptableObject
    {
        [SerializeField]
        private string elementName;

        [SerializeField]
        private Element[] elements;

        public PassiveSkill Lottery() => elements.Lottery(x => x.Weight).PassiveSkill;

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
