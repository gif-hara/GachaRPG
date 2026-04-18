using System;
using HK;
using UnityEngine;

namespace GachaRPG
{
    [Serializable]
    public class InstanceGachaElement
    {
        [SerializeField]
        private string gachaElementId;

        [SerializeField]
        private int level;

        private GachaElement cachedGachaElement;

        public GachaElement GachaElement => cachedGachaElement ??= TinyServiceLocator.Resolve<GameRule>().GachaElements.Get(gachaElementId);

        public InstancePassiveSkill Lottery()
        {
            var gachaElement = TinyServiceLocator.Resolve<GameRule>().GachaElements.Get(gachaElementId);
            var passiveSkill = gachaElement.Lottery();
            return new InstancePassiveSkill(passiveSkill.name, level);
        }

        [Serializable]
        public sealed class DictionaryList : DictionaryList<string, InstanceGachaElement>
        {
            public DictionaryList() : base(element => element.gachaElementId)
            {
            }
        }
    }
}
