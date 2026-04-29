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
        public async static UniTask<(int index, bool isCancel)> SelectGachaElementIndexAsync(this UIViewList uiViewList, Gacha gacha, CancellationToken cancellationToken)
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

            var elementButtonTask = elementButtons.Count > 0
                ? UniTask.WhenAny(elementButtons.Select(x => x.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask()))
                : UniTask.Never<(int winArgumentIndex, Unit)>(cancellationToken);
            var cancelTask = cancelButton.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask();

            var result = await UniTask.WhenAny(elementButtonTask, cancelTask);

            if (result.winArgumentIndex == 0)
            {
                return (index: result.result1.winArgumentIndex, isCancel: false);
            }
            else
            {
                return (index: -1, isCancel: true);
            }
        }

        public async static UniTask<(InstanceGachaElement instanceGachaElement, bool isCancel, bool isUnequipped)> SelectInstanceGachaElementAsync(
            this UIViewList uiViewList,
            InstanceGachaElement.DictionaryList elements,
            ICondition<InstanceGachaElement> condition,
            bool showCancelButton,
            bool showUnequippedButton,
            CancellationToken cancellationToken
            )
        {
            var unequippedButton = showUnequippedButton
                ? uiViewList.CreateButton()
                : null;
            unequippedButton?.ButtonText.SetText("外す");

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

            var cancelButton = showCancelButton
                ? uiViewList.CreateButton()
                : null;
            cancelButton?.ButtonText.SetText("戻る");

            var elementButtonTask = elementButtons.Count > 0
                ? UniTask.WhenAny(elementButtons.Select(x => x.button.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask()))
                : UniTask.Never<(int winArgumentIndex, Unit)>(cancellationToken);
            var cancelTask = cancelButton != null
                ? cancelButton.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask()
                : UniTask.Never<Unit>(cancellationToken);
            var unequippedTask = unequippedButton != null
                ? unequippedButton.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask()
                : UniTask.Never<Unit>(cancellationToken);

            var result = await UniTask.WhenAny(elementButtonTask, cancelTask, unequippedTask);

            if (result.winArgumentIndex == 0)
            {
                return (elementButtons[result.result1.winArgumentIndex].instanceGachaElement, isCancel: false, isUnequipped: false);
            }
            else if (result.winArgumentIndex == 1)
            {
                return (null, isCancel: true, isUnequipped: false);
            }
            else
            {
                return (null, isCancel: false, isUnequipped: true);
            }
        }

        public async static UniTask<(GachaResult gachaResult, bool isCancel)> SelectGachaResultAsync(this UIViewList uiViewList, GachaResult.DictionaryList gachaResults, ICondition<GachaResult> condition, CancellationToken cancellationToken)
        {
            var elementButtons = new List<(UIElementButton button, GachaResult gachaResult)>();
            foreach (var gachaResult in gachaResults.List)
            {
                if (!condition.EvaluateSafe(gachaResult))
                {
                    continue;
                }
                var button = uiViewList.CreateButton();
                button.ButtonText.SetText($"[{gachaResult.InstanceId}]");
                elementButtons.Add((button, gachaResult));
            }

            var cancelButton = uiViewList.CreateButton();
            cancelButton.ButtonText.SetText("戻る");

            var resultButtonTask = elementButtons.Count > 0
                ? UniTask.WhenAny(elementButtons.Select(x => x.button.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask()))
                : UniTask.Never<(int winArgumentIndex, Unit)>(cancellationToken);
            var cancelTask = cancelButton.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask();

            var result = await UniTask.WhenAny(resultButtonTask, cancelTask);

            if (result.winArgumentIndex == 0)
            {
                return (elementButtons[result.result1.winArgumentIndex].gachaResult, isCancel: false);
            }
            else
            {
                return (null, isCancel: true);
            }
        }
    }
}
