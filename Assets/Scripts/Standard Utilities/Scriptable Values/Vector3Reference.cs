using UnityEngine;

namespace StandardUtilities.ScriptableValues
{
    [System.Serializable]
    public class Vector3Reference
    {
        public bool useConstant;
        public Vector3Variable variable;
        public Vector3 constantValue;

        public Vector3 Value
        {
            get { return useConstant ? constantValue : variable.Value; }
        }

        public static implicit operator Vector3(Vector3Reference reference)
        {
            return reference.Value;
        }
    }
}