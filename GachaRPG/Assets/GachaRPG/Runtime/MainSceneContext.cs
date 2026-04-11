using HKFeedback;

namespace GachaRPG
{
    public readonly struct MainSceneContext : IProvider<MainSceneContext>, IProvider<UIViewList>, IProvider<MainSceneController>
    {
        public readonly MainSceneController MainSceneController { get; }

        public readonly UserData UserData { get; }

        public readonly UIViewList UIViewList { get; }

        MainSceneContext IProvider<MainSceneContext>.Provide() => this;

        UIViewList IProvider<UIViewList>.Provide() => UIViewList;

        MainSceneController IProvider<MainSceneController>.Provide() => MainSceneController;

        public MainSceneContext(MainSceneController mainSceneController, UserData userData, UIViewList uiViewList)
        {
            MainSceneController = mainSceneController;
            UserData = userData;
            UIViewList = uiViewList;
        }
    }
}
