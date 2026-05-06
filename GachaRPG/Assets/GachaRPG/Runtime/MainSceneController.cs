using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using HK;
using R3;
using HK;
using UnityEngine;

namespace GachaRPG
{
    public class MainSceneController : MonoBehaviour
    {
        [SerializeField]
        private GameRule gameRule;

        [SerializeField]
        private CharacterSpec[] initialCharacterSpecs;

        [SerializeField]
        private InstanceGachaElement[] initialInstanceGachaElementsToUserData;

        [SerializeField]
        private MainSceneFlow entryFlow;

        [SerializeField]
        private UIViewList uiViewList;

        [SerializeField]
        private UIViewInformation uiViewInformation;

        private UserData userData;

        private readonly Stack<MainSceneFlow> flowStack = new();

        public int SelectedGacha_GachaElementIndex { get; set; }

        public InstanceGachaElement SelectedInstanceGachaElement { get; set; }

        public GachaResult SelectedGachaResult { get; set; }

        private readonly MessageBroker broker = new();

        private void Start()
        {
            TinyServiceLocator.Register(gameRule)
                .RegisterTo(destroyCancellationToken);
            var gacha = new Gacha(gameRule.GachaElementSize);
            userData = new UserData(gacha);
            foreach (var spec in initialCharacterSpecs)
            {
                userData.AddCharacter(new Character(spec));
            }
            foreach (var element in initialInstanceGachaElementsToUserData)
            {
                userData.AddInstanceGachaElement(element);
                if (element.GachaEquipmentIndex >= 0 && element.GachaEquipmentIndex < gameRule.GachaElementSize)
                {
                    gacha.SetGachaElement(element.GachaEquipmentIndex, element);
                }
            }
            uiViewInformation.Initialize(CreateContext);
            PushFlowAsync(entryFlow).Forget();
        }

        public UniTask PushFlowAsync(MainSceneFlow flow)
        {
            flowStack.Push(flow);
            return flow.PlayAsync(CreateContext, destroyCancellationToken);
        }

        public UniTask PopFlowAsync()
        {
            if (flowStack.Count <= 1)
            {
                return UniTask.CompletedTask;
            }
            flowStack.Pop();
            return flowStack.Peek().PlayAsync(CreateContext, destroyCancellationToken);
        }

        private MainSceneContext CreateContext => new(this, gameRule, userData, uiViewList, uiViewInformation, broker);
    }
}
