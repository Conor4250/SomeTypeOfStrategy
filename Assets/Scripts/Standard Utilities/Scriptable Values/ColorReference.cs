using UnityEngine;

namespace StandardUtilities.ScriptableValues
{
    [System.Serializable]
    public class ColorReference
    {
        public bool useConstant;
        public ColorVariable variable;
        public Color constantValue;

        public Color Value
        {
            get { return useConstant ? constantValue : variable.Value; }
        }

        public static implicit operator Color(ColorReference reference)
        {
            return reference.Value;
        }
    }
}