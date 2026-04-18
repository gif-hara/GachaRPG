using System.Linq;
using UnityEditor;
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

        [field: SerializeField]
        public PassiveSkill.DictionaryList PassiveSkills { get; private set; } = null!;

        [ContextMenu("Setup")]
        private void Setup()
        {
            var passiveSkills = AssetDatabase.FindAssets("t:PassiveSkill", new[] { "Assets/GachaRPG/Database/PassiveSkill" })
                .Select(guid => AssetDatabase.LoadAssetAtPath<PassiveSkill>(AssetDatabase.GUIDToAssetPath(guid)))
                .ToArray();
            if (PassiveSkills == null)
            {
                PassiveSkills = new PassiveSkill.DictionaryList();
            }
            foreach (var passiveSkill in passiveSkills)
            {
                if (!PassiveSkills.ContainsKey(passiveSkill.name))
                {
                    PassiveSkills.Add(passiveSkill);
                }
            }
        }
    }
}
