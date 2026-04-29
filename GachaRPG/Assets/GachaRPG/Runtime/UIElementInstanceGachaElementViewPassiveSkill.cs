using UnityEngine;

namespace GachaRPG
{
    public sealed class UIElementInstanceGachaElementViewPassiveSkill : UIElementInstanceGachaElementViewBase
    {
        [SerializeField]
        private Transform parent;

        [SerializeField]
        private UIElementLabel label;

        public override void Apply(InstanceGachaElement element)
        {
            if (element == null)
            {
                return;
            }
            foreach (var passiveSkillElement in element.GachaElement.Elements)
            {
                var instance = Instantiate(label, parent);
                instance.SetLabel(passiveSkillElement.PassiveSkill.SkillName);
            }
        }
    }
}
