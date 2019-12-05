using UnityEngine;

namespace StandardUtilities.ScriptableValues
{
    [CreateAssetMenu(menuName ="Scriptable Values/StringVariable")]
    public class StringVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public string Value;
		
		private void OnEnable()
        {
            ((Object)this).hideFlags = HideFlags.DontUnloadUnusedAsset;
        }
		
        public void SetValue(string value)
        {
            Value = value;
        }

        public void SetValue(StringReference value)
        {
            Value = value.Value;
        }
    }
}