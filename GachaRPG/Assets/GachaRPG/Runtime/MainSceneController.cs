using Cysharp.Threading.Tasks;
using HKFeedback;
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
            var context = new MainSceneContext(uiViewList);
            entryFlow.PlayAsync(context, destroyCancellationToken).Forget();
        }
    }
}
