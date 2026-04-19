using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback;
using UnityEngine.Assertions;

namespace GachaRPG.HKFeedback.Actions
{
    [Serializable]
    public sealed class SetUserDataGachaGachaElement<TContext> : IFeedback<TContext> where TContext : IProvider<MainSceneContext>
    {
        public UniTask PlayAsync(TContext context, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return UniTask.CompletedTask;
            }
            var mainSceneContext = context.Provide();
            var selectedIndex = mainSceneContext.MainSceneController.SelectedGacha_GachaElementIndex;

            Assert.IsTrue(selectedIndex >= 0 && selectedIndex < mainSceneContext.UserData.Gacha.Elements.Count, $"Selected index {selectedIndex} is out of range.");

            mainSceneContext.UserData.Gacha.SetGachaElement(selectedIndex, mainSceneContext.MainSceneController.SelectedInstanceGachaElement);
            return UniTask.CompletedTask;
        }
    }
}
