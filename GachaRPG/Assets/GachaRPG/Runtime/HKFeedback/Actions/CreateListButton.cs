using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback;

namespace GachaRPG.HKFeedback.Actions
{
    [Serializable]
    public sealed class CreateListButton<TContext> : IFeedback<TContext>
    {
        public UniTask PlayAsync(TContext context, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
