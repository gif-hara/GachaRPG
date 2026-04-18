using System;
using Cysharp.Threading.Tasks;
using HK;
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

        [Serializable]
        public sealed class DictionaryList : DictionaryList<string, PassiveSkill>
        {
            public DictionaryList() : base(element => element.name)
            {
            }
        }
    }
}
