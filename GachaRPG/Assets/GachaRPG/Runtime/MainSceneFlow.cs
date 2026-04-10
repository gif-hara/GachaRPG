using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback;
using HKFeedback.Extensions;
using UnityEngine;

namespace GachaRPG
{
    [CreateAssetMenu(fileName = "MainSceneFlow", menuName = "GachaRPG/MainSceneFlow")]
    public sealed class MainSceneFlow : ScriptableObject
    {
        [SerializeReference, SubclassSelector]
        private IFeedback<MainSceneController>[] flows;

        public UniTask PlayAsync(MainSceneController controller, CancellationToken cancellationToken)
        {
            return flows.PlayAsync(controller, cancellationToken);
        }
    }
}
