using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    
    public GameObject pos;
    int NumberOfHits = 3;
    bool myturn = true;
    static int totalDamage = 0;
    public Button nappi;
    public Button PotionNappi;
    float timeLeft= 8;
    public Text teksti;
    public Text attackTeksti;
    bool palloLuotu = true;
    public Image paneeli;
    public Sprite kuva;
    public Text gameOver;
    public Canvas canvas;
    int potionCount;
    Text potionCountText;

    [SerializeField]
    private HealthScript player_health;

    public static int attack;
    public float speed = 1;
    public int defence;
    public AnimationController animator;



    public List<Vector2> pallolist = new List<Vector2>();

    private void Awake()
    {

        totalDamage = 0;
    }
    // Use this for initialization
    void Start () {
        potionCountText = PotionNappi.GetComponentInChildren<Text>();
        player_health.maxHealth = (int)CharacterScript.Vitality;
        player_health.currHealth = (int)CharacterScript.Vitality;
        attack =  (int)Mathf.Round(CharacterScript.Attack);
        defence = (int)Mathf.Round(CharacterScript.Defence);
        Debug.Log("statsitestaus");
        Debug.Log(player_health.currHealth + " , " + attack + " , " + speed + " , " + defence);
        potionCount = PlayerPrefs.GetInt("8amount",0);
        player_health.startTime = Time.time;
        player_health.allowFillAmount = true;
        if (potionCount <= 0)
        {
            PotionNappi.gameObject.SetActive(false);
        }

        //  camera = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        potionCountText.text = "Use Potion(" + potionCount.ToString() + ")";
       
        
        if (turnmanager.Check_turn() == true && myturn== true)
        {
            if (totalDamage != 0)
            {
                Debug.Log(totalDamage);
                
                Debug.Log(totalDamage);
                int attack = Enemy.getAttack();
                Debug.Log(totalDamage * attack);
                Debug.Log(attack);
                player_health.currHealth -= (totalDamage * attack - totalDamage * defence);
                animator.StartCoroutine("enemyattackMove", 0.2f);
                totalDamage = 0;
            }
            
            pepsi();
            if (timeLeft < 8)
            {

                timeLeft = 8;
            }
            if (player_health.currHealth > 0)
            {

                nappi.gameObject.SetActive(true);
                if (potionCount > 0)
                {
                    PotionNappi.gameObject.SetActive(true);
                }
            }



        }
        if (nappi.gameObject.activeSelf == false && turnmanager.Check_turn() == true)
        {


            timeLeft -= Time.deltaTime;
            Mathf.Round(timeLeft);
            teksti.text = "Time left :" + (int)timeLeft;
            if (timeLeft < 0)
            {
                turnmanager.set_turn();
                myturn = true;
                StopAllCoroutines();
                Delete();

            }
        }


    }
    IEnumerator GiveHits(int hits)
    {
        Debug.Log("pelaaan hp;" + player_health.currHealth);
        int i = 0;
        int j = hits;
        pallolist.Add(new Vector2(100,100));
        attackTeksti.text = j + " / " + hits;

        while (i < hits)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 v2 = Input.mousePosition;

                v2 = Camera.main.ScreenToWorldPoint(v2);


                foreach (Vector2 item in pallolist)
                {
                    
                    //Debug.Log(Vector2.Distance(v2, item));

                    if (Vector2.Distance(v2, item) < 1)
                    {

                        palloLuotu = false;

                    }
                }

                if(palloLuotu == true) {
                    Instantiate(pos, v2, Quaternion.identity);
                    i++;
                    j--;
                    Enemy.takeDamage(1);
                    pallolist.Add(v2);
                }

                palloLuotu = true;
                attackTeksti.text = j + " / " + hits;
            }
            
            yield return null;
        }

        turnmanager.set_turn();
        myturn = true;
        //Invoke("Delete", 0.3f);
    }
    void Delete()
    {
        GameObject[] killemall;
        killemall = GameObject.FindGameObjectsWithTag("Pallo");
        pallolist.Clear();
        for (int i = 0; i < killemall.Length; i++)
        {
            Destroy(killemall[i].gameObject);
        }
    }
    public static void takeDamage(int osumat)
    {
        totalDamage += osumat;
        Debug.Log(totalDamage + "takedmg");
    }
    void pepsi()
    {
        
        if (player_health.currHealth <= 0)
        {
            totalDamage = 0;
            //MenuScript.loadtownMenu();
            gameOver.text = "You lost";
            paneeli.gameObject.SetActive(true);
            Image voitto = paneeli.GetComponent<Image>();
            voitto.sprite = kuva;
            this.gameObject.SetActive(false);

        }
    }
    public void startTurn()
    {
        nappi.gameObject.SetActive(false);
        PotionNappi.gameObject.SetActive(false);


        StartCoroutine(GiveHits(NumberOfHits));
        
        myturn = false;
        NumberOfHits++;
    }
    public static int getAttack()
    {
        return attack;
    }
    public void usePotion()
    {
        nappi.gameObject.SetActive(false);
        PotionNappi.gameObject.SetActive(false);
        potionCount--;
        PlayerPrefs.SetInt("8amount", potionCount);
        player_health.currHealth  = player_health.currHealth + (player_health.maxHealth * 0.25F);
        player_health.startTime = Time.time;
        player_health.allowFillAmount = true;
        turnmanager.set_turn();
        myturn = true;
        NumberOfHits++;
    }
    //void OnMouseDown()
    //{
    //    // this object was clicked - do something
    //    if (gameObject.tag == "Pallo")
    //    {
    //        Debug.Log("ei voi laittaa");

    //    }
    //}
    

}
