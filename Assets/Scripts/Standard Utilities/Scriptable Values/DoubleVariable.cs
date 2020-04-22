using UnityEngine;

namespace StandardUtilities.ScriptableValues
{
    [CreateAssetMenu(menuName ="Scriptable Values/DoubleVariable")]
    public class DoubleVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public double Value;
		
		private void OnEnable()
        {
            ((Object)this).hideFlags = HideFlags.DontUnloadUnusedAsset;
        }
		
        public void SetValue(double value)
        {
            Value = value;
        }

        public void SetValue(DoubleReference value)
        {
            Value = value.Value;
        }

        public void ApplyChange(double amount)
        {
            Value += amount;
        }

        public void ApplyChange(DoubleReference amount)
        {
            Value += amount.Value;
        }
    }
}