using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class EnemyDatabase : MonoBehaviour
{

    private List<enemies> database1 = new List<enemies>();
    private JsonData enemyData;


    void Start()
    {

        TextAsset file = Resources.Load("enemies") as TextAsset;
        //string content = file.ToString();

        enemyData = JsonMapper.ToObject(file.ToString());
        //Item item = new Item(0, "Ball", 5);
        //database.Add(item);
        //enemyData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/enemies.json"));
        ConstructenemyDatabase();

    }

    public enemies getenemybyId(int id)
    {
        for (int i = 0; i < database1.Count; i++)
        {
            if (database1[i].ID == id)
                return database1[i];
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ConstructenemyDatabase()
    {
        for (int i = 0; i < enemyData.Count; i++)
        {
            database1.Add(new enemies((int)enemyData[i]["id"], enemyData[i]["title"].ToString(),
                 (int)enemyData[i]["stats"]["attack"], (int)enemyData[i]["stats"]["vitality"],
                 (int)enemyData[i]["stats"]["defence"], (int)enemyData[i]["stats"]["experience"], 
                 (int)enemyData[i]["stats"]["numberofhits"], enemyData[i]["description"].ToString(), enemyData[i]["slug"].ToString()
                ));
        }

    }
}


public class enemies
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Attack { get; set; }
    public int Vitality { get; set; }
    public int Defence { get; set; }
    public int Experience { get; set; }
    public int Numberofhits { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public Sprite AttackSprite { get; set; }
    public Sprite DefenceSprite { get; set; }
    public GameObject Idle { get; set; }

    public enemies(int id, string title, int attack, int vitality, int defence,int experience,int numberofhits, string description, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Attack = attack;
        this.Vitality = vitality;
        this.Defence = defence;
        this.Experience = experience;
        this.Numberofhits = numberofhits;
        this.Description = description;
        this.Slug = slug;
        this.AttackSprite = Resources.Load<Sprite>("Graphics/Enemies/"+ slug + "/attack_"+ slug);
        this.DefenceSprite = Resources.Load<Sprite>("Graphics/Enemies/" + slug +"/defence_" + slug);
        this.Idle = Resources.Load<GameObject>("Graphics/Enemies/" + slug +"/" +slug+"_idle" + "/" + slug);
    }

    public enemies()
    {

        this.ID = -1;
    }
}

