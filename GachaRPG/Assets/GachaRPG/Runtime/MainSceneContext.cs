using HKFeedback;

namespace GachaRPG
{
    public readonly struct MainSceneContext : IProvider<MainSceneContext>, IProvider<UIViewList>
    {
        public readonly UIViewList UIViewList { get; }

        MainSceneContext IProvider<MainSceneContext>.Provide() => this;

        UIViewList IProvider<UIViewList>.Provide() => UIViewList;

        public MainSceneContext(UIViewList uiViewList)
        {
            UIViewList = uiViewList;
        }
    }
}
