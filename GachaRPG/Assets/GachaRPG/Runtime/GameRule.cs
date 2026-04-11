using UnityEngine;

namespace GachaRPG
{
    [CreateAssetMenu(fileName = "GameRule", menuName = "GachaRPG/GameRule")]
    public sealed class GameRule : ScriptableObject
    {
        [field: SerializeField]
        public int UserPartySize { get; private set; } = 3;

        [field: SerializeField]
        public int GachaElementSize { get; private set; } = 3;
    }
}
