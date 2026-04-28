using System;
using HK;
using HKFeedback;
using UnityEngine;

namespace GachaRPG
{
    [Serializable]
    public class InstanceGachaElement : IProvider<InstanceGachaElement>
    {
        [SerializeField]
        private string gachaElementId;

        [SerializeField]
        private int level;

        [SerializeField]
        private int gachaEquipmentIndex = -1;

        private GachaElement cachedGachaElement;

        public GachaElement GachaElement => cachedGachaElement ??= TinyServiceLocator.Resolve<GameRule>().GachaElements.Get(gachaElementId);

        InstanceGachaElement IProvider<InstanceGachaElement>.Provide() => this;

        public int GachaEquipmentIndex
        {
            get => gachaEquipmentIndex;
            set => gachaEquipmentIndex = value;
        }

        public InstancePassiveSkill Lottery()
        {
            var passiveSkill = GachaElement.Lottery();
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
