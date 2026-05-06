namespace GachaRPG
{
    public static class MainSceneEvent
    {
        public readonly struct GachaResultSelected
        {
            public GachaResult GachaResult { get; }

            public GachaResultSelected(GachaResult gachaResult)
            {
                GachaResult = gachaResult;
            }
        }
    }
}
