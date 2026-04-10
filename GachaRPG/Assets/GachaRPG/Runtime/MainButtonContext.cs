using HKFeedback;
using TMPro;

namespace GachaRPG
{
    public readonly struct MainButtonContext : IProvider<MainButtonContext>, IProvider<MainSceneContext>, IProvider<UIElementButton>, IProvider<TMP_Text>
    {
        public readonly MainSceneContext MainSceneContext { get; }

        public readonly UIElementButton Button { get; }

        MainButtonContext IProvider<MainButtonContext>.Provide() => this;

        MainSceneContext IProvider<MainSceneContext>.Provide() => MainSceneContext;

        UIElementButton IProvider<UIElementButton>.Provide() => Button;

        TMP_Text IProvider<TMP_Text>.Provide() => Button.ButtonText;

        public MainButtonContext(MainSceneContext mainSceneContext, UIElementButton button)
        {
            MainSceneContext = mainSceneContext;
            Button = button;
        }
    }
}
