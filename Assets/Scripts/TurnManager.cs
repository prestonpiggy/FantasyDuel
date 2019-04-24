using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnmanager : MonoBehaviour
{
    public static bool PlayerTurn = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }


    //koodi taisteluvuoron vaihtamiseen
    public static void set_turn()
    {
        if (PlayerTurn == true)
        {
            PlayerTurn = false;
            
        }
        else
        {
            PlayerTurn = true;
            
        }
    }

    //palauttaa senhetkisen pelaajan vuoron tilan booleanina
    public static bool Check_turn()
    {
        return PlayerTurn;
    }
}
