using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterScript : MonoBehaviour
{
    int warriorCreated = 0;
    int mageCreated = 0;
    int rogueCreated = 0;// 0 new char 1 alrdy made char--> load old stats
    public static string ClassName { get; set; }
    public static float Vitality { get; set; }
    public static float Attack { get; set; }
    public static float Defence { get; set; }
    public static int Level { get; set; }
    public static int currentXp { get; set; }

    //public static float Speed                                                     
    //{
    //    get
    //    {
    //        return Speed;
    //    }
    //    set
    //    {
    //        Speed = value;
    //    }
    //}

    void Start()
    {

        PlayerPrefs.DeleteAll();
        warriorCreated = PlayerPrefs.GetInt("warriorCrated", 0);
        mageCreated = PlayerPrefs.GetInt("mageCreated", 0);
        rogueCreated = PlayerPrefs.GetInt("rogueCreated", 0);
        PlayerPrefs.SetInt("2amount", 3);
        PlayerPrefs.SetInt("WarriorSlot20", 8);
        PlayerPrefs.SetInt("8amount", 20);
        PlayerPrefs.SetInt("WarriorSlot6", 1);
        PlayerPrefs.SetInt("WarriorSlot8", 2);
        PlayerPrefs.SetInt("WarriorSlot11", 0);
        PlayerPrefs.SetInt("WarriorSlot3", 3);
        PlayerPrefs.SetInt("WarriorSlot4", 4);
        PlayerPrefs.SetInt("WarriorSlot13", 5);
        PlayerPrefs.SetInt("WarriorSlot14", 6);
        PlayerPrefs.SetInt("WarriorSlot15", 7);
        //Speed = 1f;
    }
    void Update()
    {
        
        
        
    }
    public void onCreation(int num)
    {

        if (num == 1)
        {

            // warrior
            if (warriorCreated == 0)
            {
                Debug.Log("nolla");
                ClassName = "Warrior";
                PlayerPrefs.SetFloat("warriorAtt", 30F);
                PlayerPrefs.SetFloat("warriorDef", 15);
                PlayerPrefs.SetFloat("warriorVit", 175);
                PlayerPrefs.SetInt("warriorCrated", 1);
                PlayerPrefs.SetInt("warriorXP", 25);
                PlayerPrefs.SetInt("warriorLvl", 1);

                ClassName = "Warrior";
                Attack = PlayerPrefs.GetFloat("warriorAtt");
                Defence = PlayerPrefs.GetFloat("warriorDef");
                Vitality = PlayerPrefs.GetFloat("warriorVit");
                Level = PlayerPrefs.GetInt("warriorLvl");
                currentXp = PlayerPrefs.GetInt("warriorXP");

            }
            else
            {
                Debug.Log("muu kuin nolla");
                ClassName = "Warrior";
                Attack = PlayerPrefs.GetFloat("warriorAtt");
                Defence = PlayerPrefs.GetFloat("warriorDef");
                Vitality = PlayerPrefs.GetFloat("warriorVit");
                Level = PlayerPrefs.GetInt("warriorLvl");
                currentXp = PlayerPrefs.GetInt("warriorXP");
            }
        }
        else if (num == 2)
        {
            //mage
            if (mageCreated == 0)
            {
                Debug.Log("Olen uusi mage");
                ClassName = "Mage";
                PlayerPrefs.SetFloat("mageAtt", 30);
                PlayerPrefs.SetFloat("mageDef", 10);
                PlayerPrefs.SetFloat("mageVit", 150);
                PlayerPrefs.SetInt("mageCreated", 1);
                PlayerPrefs.SetInt("mageLvl", 1);
                PlayerPrefs.SetInt("mageXP", 0);
                ClassName = "Mage";
                Attack = PlayerPrefs.GetFloat("mageAtt");
                Defence = PlayerPrefs.GetFloat("mageDef");
                Vitality = PlayerPrefs.GetFloat("mageVit");
                Level = PlayerPrefs.GetInt("mageLvl");
                currentXp = PlayerPrefs.GetInt("mageXP");
            }
            else
            {
                Debug.Log("Olen vanha mage");
                ClassName = "Mage";
                Attack = PlayerPrefs.GetFloat("mageAtt");
                Defence = PlayerPrefs.GetFloat("mageDef");
                Vitality = PlayerPrefs.GetFloat("mageVit");
                Level = PlayerPrefs.GetInt("mageLvl");
                currentXp = PlayerPrefs.GetInt("mageXP");
            }
        }
        else if (num == 3)
        {
            // rogue
            if (rogueCreated == 0)
            {
                Debug.Log("Olen uusi rogue");
                ClassName = "Rogue";
                PlayerPrefs.SetFloat("rogueAtt", 30);
                PlayerPrefs.SetFloat("rogueDef", 10);
                PlayerPrefs.SetFloat("rogueVit", 150);
                PlayerPrefs.SetFloat("rogueSpeed", 0.85f);
                PlayerPrefs.SetInt("rogueCreated", 1);
                PlayerPrefs.SetInt("rogueLvl", 1);
                PlayerPrefs.SetInt("rogueXP", 0);
                ClassName = "Rogue";
                Attack = PlayerPrefs.GetFloat("rogueAtt");
                Defence = PlayerPrefs.GetFloat("rogueDef");
                Vitality = PlayerPrefs.GetFloat("rogueVit");
                Level = PlayerPrefs.GetInt("rogueLvl");
                currentXp = PlayerPrefs.GetInt("rogueXP");
                //Speed = PlayerPrefs.GetFloat("rogueSpeed", 0.85f);
            }
            else
            {
                Debug.Log("Olen vanha rogue");
                ClassName = "Rogue";
                Attack = PlayerPrefs.GetFloat("rogueAtt");
                Defence = PlayerPrefs.GetFloat("rogueDef");
                Vitality = PlayerPrefs.GetFloat("rogueVit");
                Level = PlayerPrefs.GetInt("rogueLvl");
                currentXp = PlayerPrefs.GetInt("rogueXP");
                //Speed = PlayerPrefs.GetFloat("rogueSpeed", 0.85f);
            }
        }
    }
   public static void warriorLvlUp()
    {
        int maxxp = checkMaxp();
        currentXp = currentXp - maxxp;
        
        Debug.Log("warriorlvlup");
        Attack += 2;
        PlayerPrefs.SetFloat("warriorAtt", Attack);
        Attack = PlayerPrefs.GetFloat("warriorAtt");
        Defence += 1;
        PlayerPrefs.SetFloat("warriorDef", Defence);
        Defence = PlayerPrefs.GetFloat("warriorDef");
        Vitality += 5;
        PlayerPrefs.SetFloat("warriorVit", Vitality);
        Vitality = PlayerPrefs.GetFloat("warriorVit");
        Level += 1;
        PlayerPrefs.SetInt("warriorLvl", Level);
        Level = PlayerPrefs.GetInt("warriorLvl");
        PlayerPrefs.SetInt("warriorXP", currentXp);
       
    
       
        
    }
    void mageLvlUp()
    {
        Attack += 2f;
        PlayerPrefs.SetFloat("mageAtt", Attack);
        Attack = PlayerPrefs.GetFloat("mageAtt");
        Defence += 1.5f;
        PlayerPrefs.SetFloat("mageDef", Defence);
        Defence = PlayerPrefs.GetFloat("mageDef");
        Vitality += 3;
        PlayerPrefs.SetFloat("mageVit", Vitality);
        Vitality = PlayerPrefs.GetFloat("mageVit");
        Level += 1;
        PlayerPrefs.SetInt("mageLvl", Level);
        Level = PlayerPrefs.GetInt("mageLvl");
    }
    void rogueLvlUp()
    {
        Attack += 2.25f;
        PlayerPrefs.SetFloat("rogueAtt", Attack);
        Attack = PlayerPrefs.GetFloat("rogueAtt");
        Defence += 1;
        PlayerPrefs.SetFloat("rogueDef", Defence);
        Defence = PlayerPrefs.GetFloat("rogueDef");
        Vitality += 3;
        PlayerPrefs.SetFloat("rogueVit", Vitality);
        Vitality = PlayerPrefs.GetFloat("rogueVit");
        Level += 1;
        PlayerPrefs.SetInt("rogueLvl", Level);
        Level = PlayerPrefs.GetInt("rogueLvl");
    }
    public static void addXP(int value)
    {
        if (ClassName == "Warrior"){
            currentXp += value;
            PlayerPrefs.SetInt("warriorXP", currentXp);
        }
        
    }
    public static int checkMaxp()
    {
        int summa = 100;
        for (int i = 3; i < Level + 2; i++)
        {
            summa += 50 * i;
        }
        return summa;
    }

}


