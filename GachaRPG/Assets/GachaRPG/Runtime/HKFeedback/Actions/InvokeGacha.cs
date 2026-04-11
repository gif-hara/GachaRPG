using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback;
using UnityEngine;

namespace GachaRPG.HKFeedback.Actions
{
    [Serializable]
    public sealed class InvokeGacha<TContext> : IFeedback<TContext> where TContext : IProvider<MainSceneContext>
    {
        public UniTask PlayAsync(TContext context, CancellationToken cancellationToken)
        {
            var mainSceneContext = context.Provide();
            var gachaResult = mainSceneContext.UserData.Gacha.Invoke();
            Debug.Log($"{gachaResult}");
            mainSceneContext.UserData.AddGachaResult(gachaResult);
            return UniTask.CompletedTask;
        }
    }
}
