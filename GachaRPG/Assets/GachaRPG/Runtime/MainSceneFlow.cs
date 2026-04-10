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
        private IFeedback<MainSceneContext>[] flows;

        public UniTask PlayAsync(MainSceneContext context, CancellationToken cancellationToken)
        {
            return flows.PlayAsync(context, cancellationToken);
        }
    }
}
