using HKFeedback;

namespace GachaRPG
{
    public readonly struct MainButtonContext : IProvider<MainButtonContext>, IProvider<MainSceneContext>, IProvider<UIElementButton>
    {
        public readonly MainSceneContext MainSceneContext { get; }

        public readonly UIElementButton Button { get; }

        MainButtonContext IProvider<MainButtonContext>.Provide() => this;

        MainSceneContext IProvider<MainSceneContext>.Provide() => MainSceneContext;

        UIElementButton IProvider<UIElementButton>.Provide() => Button;

        public MainButtonContext(MainSceneContext mainSceneContext, UIElementButton button)
        {
            MainSceneContext = mainSceneContext;
            Button = button;
        }
    }
}
