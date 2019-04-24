using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpScript : MonoBehaviour {
    
    private float fillAmount;

    [SerializeField]
    private Image content;

    [SerializeField]
    private Text valtext;

    [SerializeField]
    private float lerpSpeed;
    [SerializeField]
    private float currVal;
    

    public float maxEXP { get; set; }


    public float experience
    {
        set
        {

            string[] temp = valtext.text.Split(':');
            valtext.text = temp[0] + ": " + value;
            fillAmount = Map(value, 0, maxEXP, 0, 1);
            //Debug.Log(fillAmount);
        }


    }
    public float currXP
    {
        get
        {
            return currVal;
        }

        set
        {
            currVal = Mathf.Clamp(value, 0, maxEXP);
            experience = currVal;

        }

    }
    void Start()
    {


        int summa = 100;
        for (int i = 3; i < CharacterScript.Level + 2; i++)
        {
            summa += 50 * i;
        }
        maxEXP = summa;
        currXP = CharacterScript.currentXp;
        content.fillAmount = PlayerPrefs.GetFloat("fillAmount",0);
        //content.fillAmount = CharacterScript.currentXp / maxEXP;
        //Debug.Log(fillAmount + "alku");
    }
    // Update is called once per frame
    void Update () {
        
        
        StartCoroutine("HandleBar");


        if (content.fillAmount == 1f)
        {
            CharacterScript.warriorLvlUp();
            int summa = 100;
            for (int i = 3; i < CharacterScript.Level + 2; i++)
            {
                summa += 50 * i;
            }
            maxEXP = summa;
            content.fillAmount = 0;
        }
        if (gameObject.tag== "Inventorybar")
        {
            
            content.fillAmount = CharacterScript.currentXp / maxEXP;
        }

    }

    IEnumerator HandleBar()
    {

        yield return new WaitForSeconds(2);
        content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, 0.5f);
        PlayerPrefs.SetFloat("fillAmount", content.fillAmount);
        currXP = CharacterScript.currentXp;

    }
    

    float Map(float currExp, float minExp, float maxExp, float outMin, float outMax)
    {

        return (currExp - minExp) * (outMax - outMin) / (maxExp - minExp) + outMin;
    }
}
