using UnityEngine;

namespace StandardUtilities.ScriptableValues
{
    [CreateAssetMenu(menuName ="Scriptable Values/Vector2Variable")]
    public class Vector2Variable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public Vector2 Value;
		
		private void OnEnable()
        {
            ((Object)this).hideFlags = HideFlags.DontUnloadUnusedAsset;
        }
		
        public void SetValue(Vector2 value)
        {
            Value = value;
        }

        public void SetValue(Vector2Reference value)
        {
            Value = value.Value;
        }

        public void ApplyChange(Vector2 amount)
        {
            Value += amount;
        }

        public void ApplyChange(Vector2Reference amount)
        {
            Value += amount.Value;
        }
    }
}