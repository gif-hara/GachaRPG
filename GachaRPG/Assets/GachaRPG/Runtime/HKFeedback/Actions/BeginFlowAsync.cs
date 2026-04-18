using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback;
using UnityEngine;

namespace GachaRPG.HKFeedback.Actions
{
    [Serializable]
    public sealed class BeginFlowAsync<TContext> : IFeedback<TContext> where TContext : IProvider<MainSceneController>
    {
        [SerializeField]
        private MainSceneFlow flow;

        public UniTask PlayAsync(TContext context, CancellationToken cancellationToken)
        {
            return context.Provide().PushFlowAsync(flow);
        }
    }
}
