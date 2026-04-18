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

        public InstancePassiveSkill Lottery()
        {
            var gachaElement = TinyServiceLocator.Resolve<GameRule>().GachaElements.Get(gachaElementId);
            var passiveSkill = gachaElement.Lottery();
            return new InstancePassiveSkill(passiveSkill.name, level);
        }
    }
}
