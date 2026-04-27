using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
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

            var elementButtonTask = UniTask.WhenAny(elementButtons.Select(x => x.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask()));
            var cancelTask = cancelButton.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask();

            return UniTask.WhenAny(elementButtonTask, cancelTask)
                .ContinueWith(result => (index: result.winArgumentIndex, isCancel: result.winArgumentIndex == 1));
        }

        public static UniTask<InstanceGachaElement> SelectInstanceGachaElementAsync(this UIViewList uiViewList, InstanceGachaElement.DictionaryList elements, CancellationToken cancellationToken)
        {
            var buttons = new List<UIElementButton>();
            foreach (var element in elements.List)
            {
                var button = uiViewList.CreateButton();
                button.ButtonText.SetText(element.GachaElement.ElementName);
                buttons.Add(button);
            }

            return UniTask.WhenAny(buttons.Select(x => x.OnClickAsObservable().FirstAsync(cancellationToken).AsUniTask()))
                .ContinueWith(result => elements.List[result.winArgumentIndex]);
        }
    }
}
