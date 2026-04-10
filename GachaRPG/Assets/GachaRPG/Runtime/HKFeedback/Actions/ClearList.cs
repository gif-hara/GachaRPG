using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback;

namespace GachaRPG.HKFeedback.Actions
{
    [Serializable]
    public sealed class ClearList<TContext> : IFeedback<TContext> where TContext : IProvider<UIViewList>
    {
        public UniTask PlayAsync(TContext context, CancellationToken cancellationToken)
        {
            context.Provide().Clear();
            return UniTask.CompletedTask;
        }
    }
}
