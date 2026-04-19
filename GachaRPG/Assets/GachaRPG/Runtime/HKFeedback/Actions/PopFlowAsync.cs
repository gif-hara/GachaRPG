using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback;
using UnityEngine;

namespace GachaRPG.HKFeedback.Actions
{
    [Serializable]
    public sealed class PopFlowAsync<TContext> : IFeedback<TContext> where TContext : IProvider<MainSceneController>
    {
        public UniTask PlayAsync(TContext context, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                Debug.Log("PopFlowAsync cancelled.");
                return UniTask.CompletedTask;
            }
            return context.Provide().PopFlowAsync();
        }
    }
}
