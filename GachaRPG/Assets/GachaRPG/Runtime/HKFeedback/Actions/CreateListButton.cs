using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback;
using HKFeedback.Extensions;
using UnityEngine;

namespace GachaRPG.HKFeedback.Actions
{
    [Serializable]
    public sealed class CreateListButton<TContext> : IFeedback<TContext> where TContext : IProvider<UIViewList>
    {
        [SerializeReference, SubclassSelector]
        private IFeedback<UIElementButton>[] onCreatedFeedbacks;

        public UniTask PlayAsync(TContext context, CancellationToken cancellationToken)
        {
            var button = context.Provide().CreateButton();
            return onCreatedFeedbacks.PlayAsync(button, cancellationToken);
        }
    }
}
