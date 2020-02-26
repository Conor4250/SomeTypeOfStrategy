//using UnityEngine;

//{
//    [CreateAssetMenu(menuName = "Scriptable Values/Unit Brain")]
//    public class BrainObject : ScriptableObject
//    {
//#if UNITY_EDITOR
//        [Multiline]
//        public string DeveloperDescription = "";
//#endif
    
//    public int baseDamage, baseSpeed, baseRange, baseMaxHealth, level, player;
//    int currentExp;
//    int expValue;
//    UnitState unitState;

//    private void OnEnable()
//        {
//            ((Object)this).hideFlags = HideFlags.DontUnloadUnusedAsset;
//        }

//        public void SetValue(float value)
//        {
//            Value = value;
//        }

//        public void SetValue(FloatReference value)
//        {
//            Value = value.Value;
//        }

//        public void ApplyChange(float amount)
//        {
//            Value += amount;
//        }

//        public void ApplyChange(FloatReference amount)
//        {
//            Value += amount.Value;
//        }
//    }



//}