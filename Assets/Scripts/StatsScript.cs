//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[Serializable]
//public class Stat {
//    /// Name of the class(warrior, etc)
//    public string ClassName { get; set; }


//    //public int Vitality { get; set; }
//    //public int Attack { get; set; }
//    //public int Defence { get; set; }
//    ////public int Intelligence { get; set; }

//        [SerializeField]
//        private HealthScript bar;

//        [SerializeField]
//         private ExpScript expbar;

        

//        [SerializeField]
//        private float maxVal;

//        [SerializeField]
//        private float currVal;

//    [SerializeField]
//    private float maxExp;

//    [SerializeField]
//    private float currExp;
        

//        public float CurrVal
//        {
//            get
//            {
//                return currVal;
//            }

//            set
//            {
//                currVal = Mathf.Clamp(value, 0, MaxVal);
//                bar.health = currVal;
                
//            }
//        }

//        public float MaxVal
//        {

//        get
//        {
//            return maxVal;
//        }

//        set
//        {
//            maxVal = value;
//            bar.maxHealth = maxVal;
//        }
//    }

//    public float ExpCurrVal
//    {
//        get
//        {
//            return currExp;
//        }

//        set
//        {
//            currExp = Mathf.Clamp(value, 0, MaxVal);
//            expbar.experience = currExp;
//        }
//    }

//    public float MaxExp
//    {
//        get
//        {
//            return maxExp;
//        }

//        set
//        {
//            maxExp = value;
//        }
//    }

//    public void Itinalize()
//    {
//        MaxVal = maxVal;
//        CurrVal = currVal;
//        MaxExp = maxExp;
//        ExpCurrVal = currExp;


//    }
//}



