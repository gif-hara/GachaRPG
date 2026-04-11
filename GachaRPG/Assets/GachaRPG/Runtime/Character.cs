using System.Collections.Generic;

namespace GachaRPG
{
    public sealed class Character
    {
        public CharacterSpec BaseSpec { get; }

        public CharacterSpec CurrentSpec { get; }

        public Character(CharacterSpec baseSpec)
        {
            BaseSpec = baseSpec;
            CurrentSpec = baseSpec;
        }

        public void ApplyPassiveSkills(List<PassiveSkill> passiveSkills)
        {
            foreach (var skill in passiveSkills)
            {
                skill.Activate(new PassiveSkillContext(this));
            }
        }
    }
}
