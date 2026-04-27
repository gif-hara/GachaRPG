using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback;
using UnityEngine;

namespace GachaRPG.HKFeedback.Actions
{
    [Serializable]
    public sealed class ShowInformation<TContext> : IFeedback<TContext> where TContext : IProvider<UIViewInformation>
    {
        [SerializeField]
        private UIViewInformation.InformationType informationType;

        public UniTask PlayAsync(TContext context, CancellationToken cancellationToken)
        {
            context.Provide().Show(informationType);
            return UniTask.CompletedTask;
        }
    }
}
