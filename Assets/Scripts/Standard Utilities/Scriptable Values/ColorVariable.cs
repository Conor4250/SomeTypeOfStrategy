using UnityEngine;

namespace StandardUtilities.ScriptableValues
{
    [CreateAssetMenu(menuName ="Scriptable Values/ColorVariable")]
    public class ColorVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public Color Value;
		
		private void OnEnable()
        {
            ((Object)this).hideFlags = HideFlags.DontUnloadUnusedAsset;
        }
		
        public void SetValue(Color value)
        {
            Value = value;
        }

        public void SetValue(ColorReference value)
        {
            Value = value.Value;
        }
    }
}