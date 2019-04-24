using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sphere : MonoBehaviour
{

    public Sprite kuva;
    private SpriteRenderer sr;
    bool torjuttu;
    // Use this for initialization
    void Start()
    {

        torjuttu = false;
        sr = GetComponent<SpriteRenderer>();
        //vihollusen pallot tuhotaa 0.8s kuluttua, jos niitä ei torjuta
        if (gameObject.tag == "EnemyBall")
        {
            Invoke("destroy", 0.8f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        // määrittää torjunnan
        if (gameObject.tag == "EnemyBall" && torjuttu == false)
        {

            torjuttu = true;
            Debug.Log("torjunta");
            GameController.takeDamage(-1);
            sr.sprite = kuva;
            Invoke("destroy", 0.5f);

        }
    }

    //tuhoamisfunktio
    void destroy()
    {
        Destroy(this.gameObject);
    }
}
