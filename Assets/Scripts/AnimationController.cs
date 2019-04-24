using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DragonBones;

public class AnimationController : MonoBehaviour {
    [SerializeField]
    public Camera cam1;
    [SerializeField]
    public Camera cam2;
    //player
    public GameObject attackmove;
    public GameObject defencemove;
    public GameObject player;
    UnityArmatureComponent animator;
    //enemy
    public GameObject enemy;
    public GameObject enemyattackmove;
    public GameObject enemydefencemove;
    
    
    
    private SpriteRenderer eidle; // muutos entity renderiin
    private SpriteRenderer eattack;
    private SpriteRenderer edefence;


    public HealthScript playerHpBar;
    public HealthScript enemyHpBar;
    
    


    
    

    

    public Canvas canvas;

    // Use this for initialization
    void Start () {
        eidle = enemy.GetComponent<SpriteRenderer>();
        eattack = enemyattackmove.GetComponent<SpriteRenderer>();
        edefence = enemydefencemove.GetComponent<SpriteRenderer>();
        eattack.sprite = MenuScript.currentenemy.AttackSprite;
        edefence.sprite = MenuScript.currentenemy.DefenceSprite;
        animator = player.GetComponent<UnityArmatureComponent>();
        
    }
	
	// Update is called once per frame
	void Update () {
        

    }
    
    IEnumerator attackMove()
    {

        float startTime = Time.time;
        while (Time.time < startTime + 1.5f)
        {
            
            player.transform.position = new Vector2(-10, 1);
            enemy.transform.position = new Vector2(-100, 1);
            canvas.enabled = false;
            cam1.enabled = false;
            cam2.enabled = true;
            attackmove.SetActive(true);
            eidle.enabled = false;
            edefence.enabled = true;
            

            float angle = Mathf.LerpAngle(0, -4, (Time.time - startTime) / 1.5f);
            cam2.transform.eulerAngles = new Vector3(0, 0, angle);
            cam2.transform.position = Vector3.Lerp(cam2.transform.position, new Vector3(2, 0, -1), (Time.time - startTime) / 1f);
            yield return null;
            //Invoke("attackMove", 3);


        }
        Debug.Log("roaatio loppu");
        cam1.enabled = true;
        cam2.enabled = false;
        canvas.enabled = true;
        player.transform.position = new Vector2(-4.71f, -0.77f);
        enemy.transform.position = new Vector2(4.62f, -2.9f);
        attackmove.SetActive(false);
        eidle.enabled = true;
        edefence.enabled = false;
        enemyHpBar.startTime = Time.time;
        enemyHpBar.allowFillAmount = true;
        animator.animationName = "Warrior_attack";
        
    }
    IEnumerator enemyattackMove()
    {
        eattack.sprite = MenuScript.currentenemy.AttackSprite;
        float startTime = Time.time;
        while (Time.time < startTime + 1.5f)
        {
            player.transform.position = new Vector2(-10, 1);
            enemy.transform.position = new Vector2(-100, 1);
            canvas.enabled = false;
            cam1.enabled = false;
            cam2.enabled = true;
            eattack.enabled = true;
            eidle.enabled = false;
            defencemove.SetActive(true);
            

            float angle = Mathf.LerpAngle(0, 4, (Time.time - startTime) / 1.5f);
            cam2.transform.eulerAngles = new Vector3(0, 0, angle);
            cam2.transform.position = Vector3.Lerp(cam2.transform.position + new Vector3(-0f, 0, -1), new Vector3(-2, 0, -1), (Time.time - startTime) / 1f);
            yield return null;
            //Invoke("attackMove", 3);


        }
        enemy.transform.position = new Vector2(4.62f, -2.9f);
        player.transform.position = new Vector2(-4.71f, -0.77f);
        eattack.sprite = MenuScript.currentenemy.DefenceSprite;
        Debug.Log("roaatio loppu");
        cam1.enabled = true;
        cam2.enabled = false;
        eattack.enabled = false;
        eidle.enabled = true;
        canvas.enabled = true;
        defencemove.SetActive(false);

        eidle.enabled = true;
        playerHpBar.startTime = Time.time;
        playerHpBar.allowFillAmount = true;

    }
}
