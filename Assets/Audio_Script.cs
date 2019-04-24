using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Script : MonoBehaviour
{

    public AudioClip UI1;
    public AudioClip UI2;

    public void play1()
    {

        AudioSource.PlayClipAtPoint(UI1,transform.position,5f);

    }
    public void play2()
    {

        AudioSource.PlayClipAtPoint(UI2,transform.position);

    }

}
