using System.Linq;

namespace GachaRPG
{
    public class GachaResult
    {
        public PassiveSkill[] PassiveSkills { get; }

        public GachaResult(PassiveSkill[] passiveSkills)
        {
            PassiveSkills = passiveSkills;
        }

        public override string ToString()
        {
            return $"GachaResult: {string.Join(", ", PassiveSkills.Select(x => x.SkillName))}";
        }
    }
}
