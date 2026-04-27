using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback;
using UnityEngine;

namespace GachaRPG.HKFeedback.Actions
{
    [Serializable]
    public sealed class SelectUserDataGachaResultAsync<TContext> : IFeedback<TContext> where TContext : IProvider<MainSceneContext>
    {
        [SerializeReference, SubclassSelector]
        private IFeedback<TContext>[] selectFeedbacks;

        [SerializeReference, SubclassSelector]
        private IFeedback<TContext>[] cancelFeedbacks;

        [SerializeReference, SubclassSelector]
        private ICondition<GachaResult> condition;

        public async UniTask PlayAsync(TContext context, CancellationToken cancellationToken)
        {
            try
            {
                var mainSceneContext = context.Provide();
                var result = await mainSceneContext.UIViewList.SelectGachaResultAsync(mainSceneContext.UserData.GachaResults, condition, cancellationToken);
                if (!result.isCancel)
                {
                    mainSceneContext.MainSceneController.SelectedGachaResult = result.gachaResult;
                    foreach (var feedback in selectFeedbacks)
                    {
                        await feedback.PlayAsync(context, cancellationToken);
                    }
                }
                else
                {
                    foreach (var feedback in cancelFeedbacks)
                    {
                        await feedback.PlayAsync(context, cancellationToken);
                    }
                }
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
