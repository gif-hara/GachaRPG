namespace GachaRPG
{
    public class GachaResult
    {
        public PassiveSkill[] PassiveSkills { get; }

        public GachaResult(PassiveSkill[] passiveSkills)
        {
            PassiveSkills = passiveSkills;
        }
    }
}
