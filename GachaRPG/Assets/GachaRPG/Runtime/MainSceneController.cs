using Cysharp.Threading.Tasks;
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

        private void Start()
        {
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
            BeginFlowAsync(entryFlow).Forget();
        }

        public UniTask BeginFlowAsync(MainSceneFlow flow)
        {
            var context = new MainSceneContext(this, gameRule, userData, uiViewList);
            return flow.PlayAsync(context, destroyCancellationToken);
        }
    }
}
