using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback;
using HKFeedback.Extensions;
using R3;
using UnityEngine;

namespace GachaRPG.HKFeedback.Actions
{
    [Serializable]
    public sealed class SubscribeOnClickAsObservable<TContext> : IFeedback<TContext> where TContext : IProvider<MainButtonContext>
    {
        [SerializeReference, SubclassSelector]
        private IFeedback<MainButtonContext>[] feedbacks;

        public UniTask PlayAsync(TContext context, CancellationToken cancellationToken)
        {
            var button = context.Provide().Button;
            button.OnClickAsObservable()
                .SubscribeAwait((feedbacks, context), static (_, state, ct) =>
                {
                    var (feedbacks, context) = state;
                    return feedbacks.PlayAsync(context.Provide(), ct);
                })
                .RegisterTo(cancellationToken);
            return UniTask.CompletedTask;
        }
    }
}
