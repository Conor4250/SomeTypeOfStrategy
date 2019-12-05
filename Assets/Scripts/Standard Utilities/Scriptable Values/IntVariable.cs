using UnityEngine;

namespace StandardUtilities.ScriptableValues
{
    [CreateAssetMenu(menuName ="Scriptable Values/IntVariable")]
    public class IntVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public int Value;
		
		private void OnEnable()
        {
            ((Object)this).hideFlags = HideFlags.DontUnloadUnusedAsset;
        }
		
        public void SetValue(int value)
        {
            Value = value;
        }

        public void SetValue(IntReference value)
        {
            Value = value.Value;
        }

        public void ApplyChange(int amount)
        {
            Value += amount;
        }

        public void ApplyChange(IntReference amount)
        {
            Value += amount.Value;
        }
    }
}