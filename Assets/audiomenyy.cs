using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomenyy : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3, sfx4, sfx5, muusika;


    public void Button1()
    {
        src.clip = sfx1;
        src.Play();
    }
    public void Button2()
    {
        src.clip = sfx2;
        src.Play();
    }
    public void Button3()
    {
        src.clip = sfx3;
        src.Play();
    }

    public void Button4()
    {
        src.clip = sfx4;
        src.Play();
    }

    public void Button5()
    {
        src.clip = sfx5;
        src.Play();
    }


}
