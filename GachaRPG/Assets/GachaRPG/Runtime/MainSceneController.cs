using Cysharp.Threading.Tasks;
using HKFeedback;
using UnityEngine;

namespace GachaRPG
{
    public class MainSceneController : MonoBehaviour, IProvider<UIViewList>
    {
        [SerializeField]
        private MainSceneFlow entryFlow;

        [SerializeField]
        private UIViewList uiViewList;

        UIViewList IProvider<UIViewList>.Provide() => uiViewList;

        private void Start()
        {
            entryFlow.PlayAsync(this, destroyCancellationToken).Forget();
        }
    }
}
