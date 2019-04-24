using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : MonoBehaviour
{

    public List<Button> storybuttons = new List<Button>();
    public static int _storyprogress = 0;
    int maxStory;


    void Start()
    {
        //PlayerPrefs.DeleteKey("currentstory");
        Debug.Log(PlayerPrefs.GetInt("currentstory")+ " currentsstory");
        maxStory = 2;
        if (PlayerPrefs.GetInt("currentstory") < maxStory)
        {

            //PlayerPrefs.DeleteAll();
            if (PlayerPrefs.GetInt("currentstory") != 0)
            {
                Debug.Log("currentstory" + PlayerPrefs.GetInt("currentstory"));
                _storyprogress = PlayerPrefs.GetInt("currentstory");
            }
            Debug.Log("storyprogress " + _storyprogress);

            for (int i = 0; i <= _storyprogress; i++)
            {
                storybuttons[i].interactable = true;
            }
        }else
        {
            for (int i = 0; i <= maxStory; i++)
            {
                storybuttons[i].interactable = true;
            }
        }

    }

    //public void storyprogress(int value)
    //{
    //     _storyprogress ++;
    //     storybuttons[_storyprogress].interactable = true;
    //      PlayerPrefs.SetInt("currentstory", _storyprogress);

    //}

}
