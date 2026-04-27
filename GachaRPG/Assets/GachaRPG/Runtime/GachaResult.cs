using System.Collections.Generic;
using System.Linq;
using HK;

namespace GachaRPG
{
    public class GachaResult
    {
        public int InstanceId { get; private set; }

        public List<InstancePassiveSkill> PassiveSkills { get; }

        public GachaResult(int instanceId, List<InstancePassiveSkill> passiveSkills)
        {
            InstanceId = instanceId;
            PassiveSkills = passiveSkills;
        }

        public override string ToString()
        {
            return $"GachaResult (InstanceId: {InstanceId}): {string.Join(", ", PassiveSkills.Select(x => x.PassiveSkill.SkillName))}";
        }

        public sealed class DictionaryList : DictionaryList<int, GachaResult>
        {
            public DictionaryList() : base(element => element.InstanceId)
            {
            }
        }
    }
}
