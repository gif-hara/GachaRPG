using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback;
using R3;
using UnityEngine;

namespace GachaRPG.HKFeedback.Actions
{
    [Serializable]
    public sealed class SelectUserDataGachaIndexAsync<TContext> : IFeedback<TContext> where TContext : IProvider<MainSceneContext>
    {
        public async UniTask PlayAsync(TContext context, CancellationToken cancellationToken)
        {
            try
            {
                var mainSceneContext = context.Provide();
                var buttons = new List<UIElementButton>();
                for (var i = 0; i < mainSceneContext.UserData.Gacha.Elements.Count; i++)
                {
                    var button = mainSceneContext.UIViewList.CreateButton();
                    var gachaElement = mainSceneContext.UserData.Gacha.Elements[i];
                    button.ButtonText.SetText($"[{i}] {(gachaElement == null ? "" : gachaElement.GachaElement.ElementName)}");
                    buttons.Add(button);
                }

                var result = await UniTask.WhenAny(buttons.Select(x => x.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask()));
                mainSceneContext.UserData.Gacha.SelectElementIndex = result.winArgumentIndex;
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
