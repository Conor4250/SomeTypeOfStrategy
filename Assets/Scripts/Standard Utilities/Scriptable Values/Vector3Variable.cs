using UnityEngine;

namespace StandardUtilities.ScriptableValues
{
    [CreateAssetMenu(menuName ="Scriptable Values/Vector3Variable")]
    public class Vector3Variable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public Vector3 Value;
		
		private void OnEnable()
        {
            ((Object)this).hideFlags = HideFlags.DontUnloadUnusedAsset;
        }
		
        public void SetValue(Vector3 value)
        {
            Value = value;
        }

        public void SetValue(Vector3Reference value)
        {
            Value = value.Value;
        }

        public void ApplyChange(Vector3 amount)
        {
            Value += amount;
        }

        public void ApplyChange(Vector3Reference amount)
        {
            Value += amount.Value;
        }
    }
}