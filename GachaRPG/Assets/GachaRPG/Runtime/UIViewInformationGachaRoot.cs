using System.Collections.Generic;
using R3;
using UnityEngine;
using UnityEngine.Assertions;

namespace GachaRPG
{
    public class UIViewInformationGachaRoot : UIViewInformationBase
    {
        [SerializeField]
        private Transform uiElementInstanceGachaElementParent;

        [SerializeField]
        private UIElementInstanceGachaElement uiElementInstanceGachaElement;

        private List<UIElementInstanceGachaElement> uiElementInstanceGachaElements = new();

        private UserData userData;

        private void OnEnable()
        {
            UpdateView();
        }

        public override void Initialize(MainSceneContext context)
        {
            userData = context.UserData;
            userData.Gacha.Broker.Receive<GachaEvent.InstanceGachaElementChanged>()
                .Subscribe(this, static (_, @this) => @this.UpdateView())
                .RegisterTo(destroyCancellationToken);
        }

        private void UpdateView()
        {
            Assert.IsNotNull(userData, $"{nameof(userData)} is not set.");

            foreach (var uiElementInstanceGachaElement in uiElementInstanceGachaElements)
            {
                Destroy(uiElementInstanceGachaElement.gameObject);
            }
            uiElementInstanceGachaElements.Clear();

            foreach (var instanceGachaElement in userData.Gacha.Elements)
            {
                var instance = Instantiate(uiElementInstanceGachaElement, uiElementInstanceGachaElementParent);
                instance.Apply(instanceGachaElement);
                uiElementInstanceGachaElements.Add(instance);
            }
        }
    }
}
