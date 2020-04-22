using UnityEngine;

namespace StandardUtilities.ScriptableValues
{
    [System.Serializable]
    public class StringReference
    {
        public bool useConstant;
        public StringVariable variable;
        public string constantValue;

        public string Value
        {
            get { return useConstant ? constantValue : variable.Value; }
        }

        public static implicit operator string(StringReference reference)
        {
            return reference.Value;
        }
    }
}