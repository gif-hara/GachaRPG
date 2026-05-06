using R3;
using UnityEngine;

namespace GachaRPG
{
    public class UIViewInformationGachaResult : UIViewInformationBase
    {
        public override void Initialize(MainSceneContext context)
        {
            context.Broker.Receive<MainSceneEvent.GachaResultSelected>()
                .Where(this, static (_, @this) => @this.gameObject.activeInHierarchy)
                .Subscribe(x =>
                {
                    Debug.Log($"Gacha Result Selected: {x.GachaResult}");
                })
                .RegisterTo(destroyCancellationToken);
        }
    }
}
