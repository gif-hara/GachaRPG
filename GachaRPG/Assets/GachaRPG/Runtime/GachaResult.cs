using System.Collections.Generic;
using System.Linq;

namespace GachaRPG
{
    public class GachaResult
    {
        public List<InstancePassiveSkill> PassiveSkills { get; }

        public GachaResult(List<InstancePassiveSkill> passiveSkills)
        {
            PassiveSkills = passiveSkills;
        }

        public override string ToString()
        {
            return $"GachaResult: {string.Join(", ", PassiveSkills.Select(x => x.PassiveSkill.SkillName))}";
        }
    }
}
