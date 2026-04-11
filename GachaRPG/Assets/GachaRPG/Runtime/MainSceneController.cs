using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GachaRPG
{
    public class MainSceneController : MonoBehaviour
    {
        [SerializeField]
        private CharacterSpec[] initialCharacterSpecs;

        [SerializeField]
        private MainSceneFlow entryFlow;

        [SerializeField]
        private UIViewList uiViewList;

        private UserData userData;

        private void Start()
        {
            userData = new UserData(initialCharacterSpecs.Select(spec => new Character(spec)).ToArray());
            BeginFlowAsync(entryFlow).Forget();
        }

        public UniTask BeginFlowAsync(MainSceneFlow flow)
        {
            var context = new MainSceneContext(this, userData, uiViewList);
            return flow.PlayAsync(context, destroyCancellationToken);
        }
    }
}
