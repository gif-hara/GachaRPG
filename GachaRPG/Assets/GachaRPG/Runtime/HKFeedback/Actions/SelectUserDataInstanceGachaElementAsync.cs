using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback;
using UnityEngine;

namespace GachaRPG.HKFeedback.Actions
{
    [Serializable]
    public sealed class SelectUserDataInstanceGachaElementAsync<TContext> : IFeedback<TContext> where TContext : IProvider<MainSceneContext>
    {
        public async UniTask PlayAsync(TContext context, CancellationToken cancellationToken)
        {
            try
            {
                var mainSceneContext = context.Provide();
                var result = await mainSceneContext.UIViewList.SelectInstanceGachaElementAsync(mainSceneContext.UserData.GachaElements, cancellationToken);
                mainSceneContext.MainSceneController.SelectedInstanceGachaElement = result;
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Selection cancelled.");
            }
            catch (InvalidOperationException)
            {
                Debug.Log("No buttons available for selection.");
            }
        }
    }
}
