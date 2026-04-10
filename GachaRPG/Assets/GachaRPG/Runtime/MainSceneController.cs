using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GachaRPG
{
    public class MainSceneController : MonoBehaviour
    {
        [SerializeField]
        private MainSceneFlow entryFlow;

        [SerializeField]
        private UIViewList uiViewList;

        private void Start()
        {
            BeginFlowAsync(entryFlow).Forget();
        }

        public UniTask BeginFlowAsync(MainSceneFlow flow)
        {
            var context = new MainSceneContext(this, uiViewList);
            return flow.PlayAsync(context, destroyCancellationToken);
        }
    }
}
