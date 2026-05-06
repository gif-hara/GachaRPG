using R3;
using R3.Triggers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GachaRPG
{
    public sealed class UIElementButton : MonoBehaviour
    {
        [field: SerializeField]
        public Button Button { get; private set; }

        [field: SerializeField]
        public TMP_Text ButtonText { get; private set; }

        public Observable<Unit> OnClickAsObservable() => Button.OnClickAsObservable();

        public Observable<PointerEventData> OnPointerEnterAsObservable() => Button.OnPointerEnterAsObservable();
    }
}
