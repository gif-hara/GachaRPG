using System;
using HK;
using UnityEngine;

namespace GachaRPG
{
    [Serializable]
    public class InstancePassiveSkill
    {
        [SerializeField]
        private string passiveSkillId;

        [field: SerializeField]
        public int Level { get; private set; }

        public PassiveSkill PassiveSkill => TinyServiceLocator.Resolve<GameRule>().PassiveSkills.Get(passiveSkillId);

        public InstancePassiveSkill(string passiveSkillId, int level)
        {
            this.passiveSkillId = passiveSkillId;
            Level = level;
        }
    }
}
