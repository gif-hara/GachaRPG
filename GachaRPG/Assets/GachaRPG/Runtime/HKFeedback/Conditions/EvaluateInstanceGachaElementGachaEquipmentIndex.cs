using System;
using HKFeedback;
using UnityEngine;

namespace GachaRPG
{
    [Serializable]
    public class EvaluateInstanceGachaElementGachaEquipmentIndex<TContext> : ICondition<TContext> where TContext : IProvider<InstanceGachaElement>
    {
        [SerializeField]
        private bool isEquipment;

        public bool Evaluate(TContext context)
        {
            var instanceGachaElement = context.Provide();
            var gachaEquipmentIndex = instanceGachaElement.GachaEquipmentIndex;
            return isEquipment == (gachaEquipmentIndex >= 0);
        }
    }
}
