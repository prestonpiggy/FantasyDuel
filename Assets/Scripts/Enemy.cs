using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    enemies currentenemy;
    public GameObject pos;
    int NumberOfHits = 3;
    bool myturn = true;
    static int totalDamage = 0;
    public List<Vector3> list = new List<Vector3>();
    public Image paneeli;
    public Text gameOver;
    public static int attack = 50;
    public int defence = 15;
    public Sprite kuva;
    private SpriteRenderer sr;
    public int xpGained =  50;
    public GameObject EnemyCursor;
    private float journeyLength;
    //private bool allowCursorMovement = false;
    public float speed;
    //private bool moveForNextAttack = false;
    public GameObject currentPlayerAttack;
    public float defendTime = 0;
    private int numberOfBlocks = 0;
    public GameController gameController;
    float randomSpeed;
    public bool AttacksHaveBeenBlocked = false;
    public AnimationController animator;
    bool allowInstantiate = false;
    public GameObject blockedAttack;
    public GameObject missedAttack;
    [SerializeField]
    SpriteRenderer background;
    
    //public List<Sprite> enemylist = new List<Sprite>();

    [SerializeField]
    private HealthScript enemy_health;


    private void Awake()
    {
        //enemy_health.Itinalize();
    }

    // Use this for initialization
    void Start()
    {
        currentenemy = MenuScript.currentenemy;
        attack = MenuScript.currentenemy.Attack;
        defence = MenuScript.currentenemy.Defence;
        NumberOfHits = MenuScript.currentenemy.Numberofhits;
        xpGained = MenuScript.currentenemy.Experience;
        
        Debug.Log(currentenemy.Attack + ", enemy attack");

        EnemyCursor = GameObject.FindGameObjectWithTag("enemyCursor");

        sr = GetComponent<SpriteRenderer>();
        sr.sprite = MenuScript.currentenemy.DefenceSprite;
        //sr.sprite = kuva;

        enemy_health.maxHealth = MenuScript.currentenemy.Vitality;
        enemy_health.currHealth = MenuScript.currentenemy.Vitality;
        background.sprite = MenuScript.current;

        //  camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        //vuoron aloitus
        if (turnmanager.Check_turn() == false && myturn == true)
        {

            if (defendTime < 4)
            {
                defendTime += Time.deltaTime;
                if (!currentPlayerAttack)
                {
                    currentPlayerAttack = GameObject.FindGameObjectWithTag("Pallo");
                    allowInstantiate = true;

                    if (currentPlayerAttack)
                    {
                        if (Vector3.Distance(currentPlayerAttack.transform.position, EnemyCursor.transform.position) > 6)
                        {
                            randomSpeed = Random.Range(0.25f, 0.325f);
                        }
                        else
                        {
                            randomSpeed = Random.Range(0.05f, 0.125f);
                        }
                    }
                }
                else
                {

                    EnemyCursor.transform.position = Vector3.MoveTowards(EnemyCursor.transform.position, currentPlayerAttack.transform.position, randomSpeed);
                    if (EnemyCursor.transform.position == currentPlayerAttack.transform.position)
                    {
                        int arpa = Random.Range(1, 10);
                        Debug.Log("arpa rullataan ja tuli: " + arpa);
                        if (arpa <= 5 && allowInstantiate)
                        {
                            Debug.Log("here we are, bitches");
                            numberOfBlocks++;
                            Instantiate(blockedAttack, currentPlayerAttack.transform.position - new Vector3(0, 0, -2), Quaternion.identity);
                            Destroy(currentPlayerAttack);
                            allowInstantiate = false;

                        }
                        else
                        {
                            Instantiate(missedAttack, currentPlayerAttack.transform.position - new Vector3(0, 0, -3), Quaternion.identity);
                            allowInstantiate = false;
                            Destroy(currentPlayerAttack);
                        }

                        currentPlayerAttack = null;

                    }
                }
            }
            else
            {
                gameController.Invoke("Delete", 0.3f);
                block(totalDamage); //vihollinen 
                enemy_health.currHealth -= (totalDamage * GameController.getAttack() - totalDamage * defence); //vähennetään healthpointseja totaldamagen mukaan
                Debug.Log("enemy hp:" + enemy_health.currHealth);
                pepsi(); //tarkistetaan kuoliko vihollinen, jos damage ylitti rajan 
                if (totalDamage > 0)
                    animator.StartCoroutine("attackMove");// player attackmove jos dmg>0
                totalDamage = 0; //resetoidaan totalDamage;
                if (enemy_health.currHealth > 0)
                {
                    StartCoroutine(GiveHits(NumberOfHits)); //määrittää paikat vhollisen iskuille ja luo ne

                    GameController.takeDamage(NumberOfHits); //annetaan pelaajalle vahinkoa
                }
                myturn = false; //vuoro apumuuttuja vaihdetaan
                NumberOfHits++; //lisätään seuraavalle vuorolle hyökkäysten määrää
                defendTime = 0;
               
                EnemyCursor.transform.position = new Vector3(0, 0, 0);
            }
        }



    }
    IEnumerator GiveHits(int hits)
    {
        yield return new WaitForSeconds(3f);
        int i = 0;
        //Debug.Log(hits);

        while (i < hits)
        {
            
            
            Vector3 position = new Vector3(Random.Range(-6.0f, 6.0f), Random.Range(-3.0f, 3.0f),-1.0f );
            list.Add(position);
            
            i++;
            yield return new WaitForSeconds(2/hits);
            
        }
        
        StartCoroutine(placeHits());
        yield return null;

    }
    IEnumerator placeHits()
    {
        int a = 0;
        var res = Split(5, NumberOfHits-1);
        foreach (var item in res)
        {
            Instantiate(pos, list[a], Quaternion.identity);
            a++;
            yield return new WaitForSeconds(item);
        }

        list.Clear();
        turnmanager.set_turn();
        myturn = true;
        Invoke("Delete", 0.3f);
        yield return null;
        
    }
    void Delete()
    {
        GameObject[] killemall;
        killemall = GameObject.FindGameObjectsWithTag("EnemyBall");
        for (int i = 0; i < killemall.Length; i++)
        {
            Destroy(killemall[i].gameObject);
        }
    }
    public static void takeDamage(int osumat)
    {
        totalDamage += osumat;
    }
    void block(int osumat)
    {
        //for ( int i = 0; i < osumat; i++)
        //{
        //    int rand = Random.Range(1, 3);
        //    if (rand == 1)
        //    {
        //        numberOfBlocks++;
        //    }

        //}
        //EnemyCursor.SetActive(true);
        //GameObject[] playerAttacks;
        //playerAttacks = GameObject.FindGameObjectsWithTag("Pallo");

        //foreach (GameObject playerAttack in playerAttacks)
        //{
        //    currentPlayerAttack = playerAttack;
        //    allowCursorMovement = true;



        //    allowCursorMovement = false;
        //    moveForNextAttack = false;
        //}
        totalDamage -= numberOfBlocks;
        numberOfBlocks = 0;
        //EnemyCursor.SetActive(false);
    }
    void pepsi()
    {
        int intHP = (int)enemy_health.currHealth;
        if (enemy_health.currHealth <= 0)
        {
            CharacterScript.addXP(xpGained);
            //CharacterScript.warriorLvlUp();
            gameOver.text = "You Won!";
            paneeli.gameObject.SetActive(true);
            turnmanager.set_turn();
            continuestory();
            this.gameObject.SetActive(false);


        }
    }//random divider
    public static IEnumerable<float> Split(float val, int parts)
    {
        float left = val;
        for (int i = 0; i < parts - 1; i++)
        {
            var curr = Random.Range(1, left / parts);
            yield return curr;
            left -= curr;
        }
        yield return left;
    }
    public static int getAttack()
    {
        return attack;
    }
    public void continuestory()
    {
        if (currentenemy.ID >= PlayerPrefs.GetInt("currentstory") && MenuScript.storymode == true)
        {
            StoryManager._storyprogress = PlayerPrefs.GetInt("currentstory") + 1;
            PlayerPrefs.SetInt("currentstory", StoryManager._storyprogress);
        }
    }

}
