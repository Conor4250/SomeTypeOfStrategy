using UnityEngine;

namespace StandardUtilities.ScriptableValues
{
    [System.Serializable]
    public class IntReference
    {
        public bool useConstant;
        public IntVariable variable;
        public int constantValue;

        public int Value
        {
            get { return useConstant ? constantValue : variable.Value; }
        }

        public static implicit operator int(IntReference reference)
        {
            return reference.Value;
        }
    }
}