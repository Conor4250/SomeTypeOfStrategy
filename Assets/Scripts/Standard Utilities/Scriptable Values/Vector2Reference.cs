using UnityEngine;

namespace StandardUtilities.ScriptableValues
{
    [System.Serializable]
    public class Vector2Reference
    {
        public bool useConstant;
        public Vector2Variable variable;
        public Vector2 constantValue;

        public Vector2 Value
        {
            get { return useConstant ? constantValue : variable.Value; }
        }

        public static implicit operator Vector2(Vector2Reference reference)
        {
            return reference.Value;
        }
    }
}