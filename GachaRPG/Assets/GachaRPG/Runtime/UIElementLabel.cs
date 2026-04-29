using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GachaRPG
{
    public sealed class UIElementLabel : MonoBehaviour
    {
        [SerializeField]
        private Image iconImage;

        [SerializeField]
        private TMP_Text labelText;

        public void SetIcon(Sprite icon)
        {
            iconImage.sprite = icon;
        }

        public void SetLabel(string label)
        {
            labelText.SetText(label);
        }
    }
}
