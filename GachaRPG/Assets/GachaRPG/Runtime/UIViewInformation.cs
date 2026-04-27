using System;
using HK;
using UnityEngine;

namespace GachaRPG
{
    public class UIViewInformation : UIViewBase
    {
        [SerializeField]
        private Element.DictionaryList elements;

        public void Show(InformationType type)
        {
            foreach (var element in elements.List)
            {
                element.Root.SetActive(element.Type == type);
            }
        }

        public enum InformationType
        {
            Root,
            GachaRoot,
        }

        [Serializable]
        public class Element
        {
            [field: SerializeField]
            public InformationType Type { get; private set; }

            [field: SerializeField]
            public GameObject Root { get; private set; }

            [Serializable]
            public sealed class DictionaryList : DictionaryList<InformationType, Element>
            {
                public DictionaryList() : base(x => x.Type)
                {
                }
            }
        }
    }
}
