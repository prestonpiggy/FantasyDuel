using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{


    private float fillAmount;
    public bool allowFillAmount = false;
    public float startTime;

    [SerializeField]
    public Image content;

    [SerializeField]
    private Text valtext;

    [SerializeField]
    private float lerpSpeed;

    [SerializeField]
    private float maxVal;

    [SerializeField]
    private float currVal;
    public Canvas canvas;
    public float time;

    public float maxHealth
    {
        get
        {
            return maxVal;
        }

        set
        {
            maxVal = value;
            //maxHealth = maxVal;
        }
    }
    public float currHealth {
        get
        {
            return currVal;
        }

        set
        {
            currVal = Mathf.Clamp(value, 0, maxHealth);
            health = currVal;

        }
        
    }


    public float health
    {
        set
        {
            string[] temp = valtext.text.Split(':');
            valtext.text = temp[0] + ": " + currHealth;
            fillAmount = Map(currHealth, 0, maxHealth, 0, 1);
        }


    }


    // Update is called once per frame
    void Update()
    {
        //float time = Time.deltaTime;
        if (allowFillAmount == true)
        {
            
            StartCoroutine("HandleBar",2f);
        }


    }
    
    public void HandleBar()
    {
        
        //if (canvas.isActiveAndEnabled == true)
        //{
       
        //yield return new WaitForSeconds(4);
        content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, 0.1f);
        
        
        
        if (Time.time > startTime + 1.5f)
        {
            allowFillAmount = false;
            time = 0;
            Debug.Log("allow false");
        }
        //}
        //else
        //{
        //    Debug.Log("error canvas disabled");
        //}

    }

    float Map(float currHealth, float minHealth, float maxHealth, float outMin, float outMax)
    {

        return (currHealth - minHealth) * (outMax - outMin) / (maxHealth - minHealth) + outMin;
    }



}

