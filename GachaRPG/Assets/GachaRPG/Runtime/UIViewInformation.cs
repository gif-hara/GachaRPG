using System;
using HK;
using UnityEngine;

namespace GachaRPG
{
    public class UIViewInformation : UIViewInformationBase
    {
        [SerializeField]
        private Element.DictionaryList elements;

        public override void Initialize(MainSceneContext context)
        {
            foreach (var element in elements.List)
            {
                element.Root.Initialize(context);
            }
        }

        public void Show(InformationType type)
        {
            foreach (var element in elements.List)
            {
                element.Root.gameObject.SetActive(element.Type == type);
            }
        }

        public enum InformationType
        {
            Root,
            GachaRoot,
            GachaResult,
        }

        [Serializable]
        public class Element
        {
            [field: SerializeField]
            public InformationType Type { get; private set; }

            [field: SerializeField]
            public UIViewInformationBase Root { get; private set; }

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
