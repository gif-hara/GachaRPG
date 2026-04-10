using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback;
using HKFeedback.Extensions;
using UnityEngine;

namespace GachaRPG.HKFeedback.Actions
{
    [Serializable]
    public sealed class CreateListButton<TContext> : IFeedback<TContext> where TContext : IProvider<MainSceneContext>
    {
        [SerializeReference, SubclassSelector]
        private IFeedback<MainButtonContext>[] onCreatedFeedbacks;

        public UniTask PlayAsync(TContext context, CancellationToken cancellationToken)
        {
            var mainSceneContext = context.Provide();
            var button = mainSceneContext.UIViewList.CreateButton();
            var mainButtonContext = new MainButtonContext(mainSceneContext, button);
            return onCreatedFeedbacks.PlayAsync(mainButtonContext, cancellationToken);
        }
    }
}
