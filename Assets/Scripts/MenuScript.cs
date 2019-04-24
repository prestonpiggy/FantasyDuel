using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    public static enemies currentenemy;
    public EnemyDatabase database;
    public static Sprite current;
    public static Sprite currentattackmove;
    public Sprite lvl1;
    public Sprite lvl2;
    public Sprite lvl3;
    public static bool storymode;
    public Image exitimage;
    public Animation clip;
    public Button nobutton;



    //private void Awake()
    //{
    //    Screen.fullScreen = !Screen.fullScreen;
    //    Screen.orientation = ScreenOrientation.LandscapeLeft;

    //}

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "MenuScene") {
                clip.Play("exitimage");
            }else if(scene.name == "MainMenuScene")
            {
                Application.Quit();
                return;
            }
            //clip = GetComponent<Animation>();

            //clip.Play("exitimage");
            //quit application on return button
            //Application.Quit();
            //return;
        }
       
    }

    //lataa quickplayn
    public void activeQuickplay()
    {

        SceneManager.LoadScene("scene1");

    }

    //lataa kylänäkymän
    public static void loadtownMenu()
    {

        SceneManager.LoadScene("MenuScene");

    }
    //lataa näkymän käyttämättä static metodia
    public void load_townMenu()
    {

        SceneManager.LoadScene("MenuScene");

    }
    public void load_MainMenu()
    {

        SceneManager.LoadScene("MainMenuScene");

    }
    public void loadEnemyById(int id)
    {
        storymode = true;
        currentenemy = database.getenemybyId(id);
        setBackGround(id);


    }
    public void loadrandomenemy()
    {
        storymode = false;
        int id = Random.Range(0, PlayerPrefs.GetInt("currentstory",1));
        int id2 = Random.Range(0, PlayerPrefs.GetInt("currentstory", 1));
        setBackGround(id2);
        

        currentenemy = database.getenemybyId(id);
        //attack
        id = Random.Range(-10, 10);
        currentenemy.Attack += id;
        //def
        id = Random.Range(-10, 10);
        currentenemy.Defence += id;

        //vit
        id = Random.Range(-25, 25);
        currentenemy.Vitality += id;
    }
    private void setBackGround(int id2)
    {
        if (id2 == 0)
        {
            current = lvl1;
        }
        else if (id2 == 1)
        {
            current = lvl2;
        }
        else if (id2 == 2)
        {
            current = lvl3;
        }
        Debug.Log(id2);
    }

    public void quitgame()
    {
        Application.Quit();

    }

    public void Exitimage()
    {
        clip.Play("exitimage2");
    }
    //public void ResetGame()
    //{
    //    PlayerPrefs.DeleteAll();

    //}
}
