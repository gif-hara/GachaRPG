using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback;
using TMPro;
using UnityEngine;

namespace GachaRPG.HKFeedback.Actions
{
    [Serializable]
    public sealed class SetText<TContext> : IFeedback<TContext> where TContext : IProvider<TMP_Text>
    {
        [SerializeField]
        private string message;

        public UniTask PlayAsync(TContext context, CancellationToken cancellationToken)
        {
            context.Provide().SetText(message);
            return UniTask.CompletedTask;
        }
    }
}
