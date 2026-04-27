using System.Collections.Generic;
using UnityEngine;

namespace GachaRPG
{
    public class UIViewList : UIViewBase
    {
        [SerializeField]
        private Transform buttonParent;

        [SerializeField]
        private UIElementButton buttonPrefab;

        private readonly List<UIElementButton> buttons = new();

        public void Clear()
        {
            foreach (var button in buttons)
            {
                Destroy(button.gameObject);
            }
            buttons.Clear();
        }

        public UIElementButton CreateButton()
        {
            var button = Instantiate(buttonPrefab, buttonParent);
            buttons.Add(button);
            return button;
        }
    }
}
