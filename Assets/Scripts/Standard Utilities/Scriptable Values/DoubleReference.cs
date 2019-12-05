using UnityEngine;

namespace StandardUtilities.ScriptableValues
{
    [System.Serializable]
    public class DoubleReference
    {
        public bool useConstant;
        public DoubleVariable variable;
        public double constantValue;

        public double Value
        {
            get { return useConstant ? constantValue : variable.Value; }
        }

        public static implicit operator double(DoubleReference reference)
        {
            return reference.Value;
        }
    }
}