using HKFeedback;

namespace GachaRPG
{
    public readonly struct MainSceneContext : IProvider<MainSceneContext>, IProvider<UIViewList>, IProvider<MainSceneController>, IProvider<UserData>, IProvider<GameRule>
    {
        public readonly MainSceneController MainSceneController { get; }

        public readonly UserData UserData { get; }

        public readonly UIViewList UIViewList { get; }

        public readonly GameRule GameRule { get; }

        MainSceneContext IProvider<MainSceneContext>.Provide() => this;

        UIViewList IProvider<UIViewList>.Provide() => UIViewList;

        GameRule IProvider<GameRule>.Provide() => GameRule;

        MainSceneController IProvider<MainSceneController>.Provide() => MainSceneController;

        UserData IProvider<UserData>.Provide() => UserData;

        public MainSceneContext(MainSceneController mainSceneController, GameRule gameRule, UserData userData, UIViewList uiViewList)
        {
            MainSceneController = mainSceneController;
            GameRule = gameRule;
            UserData = userData;
            UIViewList = uiViewList;
        }
    }
}
