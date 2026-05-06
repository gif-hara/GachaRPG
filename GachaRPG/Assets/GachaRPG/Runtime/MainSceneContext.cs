using HKFeedback;
using HK;

namespace GachaRPG
{
    public readonly struct MainSceneContext : IProvider<MainSceneContext>, IProvider<UIViewList>, IProvider<MainSceneController>, IProvider<UserData>, IProvider<GameRule>, IProvider<UIViewInformation>, IProvider<IMessageBroker>
    {
        public readonly MainSceneController MainSceneController { get; }

        public readonly UserData UserData { get; }

        public readonly UIViewList UIViewList { get; }

        public readonly UIViewInformation UIViewInformation { get; }

        public readonly GameRule GameRule { get; }

        public readonly IMessageBroker Broker { get; }

        MainSceneContext IProvider<MainSceneContext>.Provide() => this;

        UIViewList IProvider<UIViewList>.Provide() => UIViewList;

        GameRule IProvider<GameRule>.Provide() => GameRule;

        MainSceneController IProvider<MainSceneController>.Provide() => MainSceneController;

        UserData IProvider<UserData>.Provide() => UserData;

        UIViewInformation IProvider<UIViewInformation>.Provide() => UIViewInformation;

        IMessageBroker IProvider<IMessageBroker>.Provide() => Broker;

        public MainSceneContext(MainSceneController mainSceneController, GameRule gameRule, UserData userData, UIViewList uiViewList, UIViewInformation uiViewInformation, IMessageBroker broker)
        {
            MainSceneController = mainSceneController;
            GameRule = gameRule;
            UserData = userData;
            UIViewList = uiViewList;
            UIViewInformation = uiViewInformation;
            Broker = broker;
        }
    }
}
