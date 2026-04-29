using UnityEngine;

namespace GachaRPG
{
    public sealed class UIElementInstanceGachaElement : MonoBehaviour
    {
        [SerializeField]
        private UIElementInstanceGachaElementViewBase[] views;

        public void Apply(InstanceGachaElement element)
        {
            foreach (var view in views)
            {
                view.Apply(element);
            }
        }
    }
}
