using Cysharp.Threading.Tasks;
using HKFeedback;
using HKFeedback.Extensions;
using UnityEngine;

namespace GachaRPG
{
    [CreateAssetMenu(fileName = "PassiveSkill", menuName = "GachaRPG/Passive Skill")]
    public class PassiveSkill : ScriptableObject
    {
        [field: SerializeField]
        public string SkillName { get; private set; }

        [SerializeReference, SubclassSelector]
        private IFeedback<PassiveSkillContext>[] actions;

        public void Activate(PassiveSkillContext context)
        {
            actions.PlayAsync(context, default).Forget();
        }
    }
}
