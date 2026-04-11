namespace GachaRPG
{
    public readonly struct PassiveSkillContext
    {
        public readonly Character Character { get; }

        public PassiveSkillContext(Character character)
        {
            Character = character;
        }
    }
}
