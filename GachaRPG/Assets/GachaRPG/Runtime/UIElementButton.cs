using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GachaRPG
{
    public sealed class UIElementButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;

        [SerializeField]
        private TMP_Text buttonText;

        public void SetText(string text) => buttonText.text = text;

        public Observable<Unit> OnClickAsObservable() => button.OnClickAsObservable();
    }
}
