using System.Collections;
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
        private GachaElement[] initialGachaElements;

        [SerializeField]
        private MainSceneFlow entryFlow;

        [SerializeField]
        private UIViewList uiViewList;

        private UserData userData;

        private readonly Stack<MainSceneFlow> flowStack = new();

        private void Start()
        {
            TinyServiceLocator.Register(gameRule)
                .RegisterTo(destroyCancellationToken);
            var gacha = new Gacha(gameRule.GachaElementSize);
            for (var i = 0; i < initialGachaElements.Length; i++)
            {
                gacha.SetGachaElement(i, initialGachaElements[i]);
            }
            userData = new UserData(gacha);
            foreach (var spec in initialCharacterSpecs)
            {
                userData.AddCharacter(new Character(spec));
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
