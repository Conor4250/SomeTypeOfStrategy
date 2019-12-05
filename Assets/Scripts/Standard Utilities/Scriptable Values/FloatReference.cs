using UnityEngine;

namespace StandardUtilities.ScriptableValues
{
    [System.Serializable]
    public class FloatReference
    {
        public bool useConstant;
        public FloatVariable variable;
        public float constantValue;

        public float Value
        {
            get { return useConstant ? constantValue : variable.Value; }
        }

        public static implicit operator float(FloatReference reference)
        {
            return reference.Value;
        }
    }
}