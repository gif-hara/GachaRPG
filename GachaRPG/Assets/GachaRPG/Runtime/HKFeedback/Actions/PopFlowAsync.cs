using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback;

namespace GachaRPG.HKFeedback.Actions
{
    [Serializable]
    public sealed class PopFlowAsync<TContext> : IFeedback<TContext> where TContext : IProvider<MainSceneController>
    {
        public UniTask PlayAsync(TContext context, CancellationToken cancellationToken)
        {
            return context.Provide().PopFlowAsync();
        }
    }
}
