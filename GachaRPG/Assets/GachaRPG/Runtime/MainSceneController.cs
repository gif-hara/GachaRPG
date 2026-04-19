using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using HK;
using R3;
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
        private InstanceGachaElement[] initialInstanceGachaElementsToGacha;

        [SerializeField]
        private MainSceneFlow entryFlow;

        [SerializeField]
        private UIViewList uiViewList;

        private UserData userData;

        private readonly Stack<MainSceneFlow> flowStack = new();

        public int SelectedGacha_GachaElementIndex { get; set; }

        public InstanceGachaElement SelectedInstanceGachaElement { get; set; }

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
            }
            for (var i = 0; i < initialInstanceGachaElementsToGacha.Length; i++)
            {
                gacha.SetGachaElement(i, initialInstanceGachaElementsToGacha[i]);
            }
            PushFlowAsync(entryFlow).Forget();
        }

        public UniTask PushFlowAsync(MainSceneFlow flow)
        {
            flowStack.Push(flow);
            var context = new MainSceneContext(this, gameRule, userData, uiViewList);
            return flow.PlayAsync(context, destroyCancellationToken);
        }

        public UniTask PopFlowAsync()
        {
            if (flowStack.Count <= 1)
            {
                return UniTask.CompletedTask;
            }
            flowStack.Pop();
            var context = new MainSceneContext(this, gameRule, userData, uiViewList);
            return flowStack.Peek().PlayAsync(context, destroyCancellationToken);
        }
    }
}
