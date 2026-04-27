using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using HKFeedback;
using HKFeedback.Extensions;
using R3;

namespace GachaRPG
{
    public static partial class Extensions
    {
        public static UniTask<(int index, bool isCancel)> SelectGachaElementIndexAsync(this UIViewList uiViewList, Gacha gacha, CancellationToken cancellationToken)
        {
            var elementButtons = new List<UIElementButton>();
            for (var i = 0; i < gacha.Elements.Count; i++)
            {
                var button = uiViewList.CreateButton();
                var gachaElement = gacha.Elements[i];
                button.ButtonText.SetText($"[{i}] {(gachaElement == null ? "-----" : gachaElement.GachaElement.ElementName)}");
                elementButtons.Add(button);
            }

            var cancelButton = uiViewList.CreateButton();
            cancelButton.ButtonText.SetText("戻る");

            if (elementButtons.Count == 0)
            {
                return cancelButton.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask()
                    .ContinueWith(_ => (index: -1, isCancel: true));
            }
            else
            {
                var elementButtonTask = UniTask.WhenAny(elementButtons.Select(x => x.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask()));
                var cancelTask = cancelButton.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask();

                return UniTask.WhenAny(elementButtonTask, cancelTask)
                    .ContinueWith(result => (index: result.result1.winArgumentIndex, isCancel: result.winArgumentIndex == 1));
            }
        }

        public static UniTask<(InstanceGachaElement instanceGachaElement, bool isCancel)> SelectInstanceGachaElementAsync(this UIViewList uiViewList, InstanceGachaElement.DictionaryList elements, ICondition<InstanceGachaElement> condition, CancellationToken cancellationToken)
        {
            var elementButtons = new List<(UIElementButton button, InstanceGachaElement instanceGachaElement)>();
            foreach (var element in elements.List)
            {
                if (!condition.EvaluateSafe(element))
                {
                    continue;
                }
                var button = uiViewList.CreateButton();
                button.ButtonText.SetText(element.GachaElement.ElementName);
                elementButtons.Add((button, element));
            }

            var cancelButton = uiViewList.CreateButton();
            cancelButton.ButtonText.SetText("戻る");

            if (elementButtons.Count == 0)
            {
                return cancelButton.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask()
                    .ContinueWith(_ => (instanceGachaElement: (InstanceGachaElement)null, isCancel: true));
            }
            else
            {
                var elementButtonTask = UniTask.WhenAny(elementButtons.Select(x => x.button.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask()));
                var cancelTask = cancelButton.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask();

                return UniTask.WhenAny(elementButtonTask, cancelTask)
                    .ContinueWith(result => (elementButtons[result.result1.winArgumentIndex].instanceGachaElement, isCancel: result.winArgumentIndex == 1));
            }
        }

        public static UniTask<(GachaResult gachaResult, bool isCancel)> SelectGachaResultAsync(this UIViewList uiViewList, GachaResult.DictionaryList gachaResults, ICondition<GachaResult> condition, CancellationToken cancellationToken)
        {
            var resultButtons = new List<(UIElementButton button, GachaResult gachaResult)>();
            foreach (var gachaResult in gachaResults.List)
            {
                if (!condition.EvaluateSafe(gachaResult))
                {
                    continue;
                }
                var button = uiViewList.CreateButton();
                button.ButtonText.SetText($"[{gachaResult.InstanceId}]");
                resultButtons.Add((button, gachaResult));
            }

            var cancelButton = uiViewList.CreateButton();
            cancelButton.ButtonText.SetText("戻る");

            if (resultButtons.Count == 0)
            {
                return cancelButton.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask()
                    .ContinueWith(_ => (gachaResult: (GachaResult)null, isCancel: true));
            }
            else
            {
                var resultButtonTask = UniTask.WhenAny(resultButtons.Select(x => x.button.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask()));
                var cancelTask = cancelButton.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask();

                return UniTask.WhenAny(resultButtonTask, cancelTask)
                    .ContinueWith(result => (resultButtons[result.result1.winArgumentIndex].gachaResult, isCancel: result.winArgumentIndex == 1));
            }
        }
    }
}
