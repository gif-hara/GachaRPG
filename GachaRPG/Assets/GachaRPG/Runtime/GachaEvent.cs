namespace GachaRPG
{
    public static class GachaEvent
    {
        public readonly struct InstanceGachaElementChanged
        {
            public InstanceGachaElement Element { get; }

            public InstanceGachaElementChanged(InstanceGachaElement element)
            {
                Element = element;
            }
        }
    }
}
