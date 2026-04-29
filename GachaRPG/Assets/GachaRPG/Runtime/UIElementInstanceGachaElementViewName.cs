using TMPro;
using UnityEngine;

namespace GachaRPG
{
    public sealed class UIElementInstanceGachaElementViewName : UIElementInstanceGachaElementViewBase
    {
        [SerializeField]
        private TMP_Text nameText;

        public override void Apply(InstanceGachaElement element)
        {
            if (element == null)
            {
                nameText.SetText(string.Empty);
                return;
            }
            nameText.SetText(element.GachaElement.ElementName);
        }
    }
}
