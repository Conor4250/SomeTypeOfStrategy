using UnityEngine;

namespace StandardUtilities.ScriptableValues
{
    [System.Serializable]
    public class BoolReference
    {
        public bool useConstant;
        public BoolVariable variable;
        public bool constantValue;

        public bool Value
        {
            get { return useConstant ? constantValue : variable.Value; }
        }

        public static implicit operator bool(BoolReference reference)
        {
            return reference.Value;
        }
    }
}