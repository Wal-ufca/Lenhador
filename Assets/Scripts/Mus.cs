using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mus : MonoBehaviour
{
    public AudioClip[] sons;
    public AudioSource[] mus;
    public static Mus m;

    int c =1;
    // Start is called before the first frame update
    void Awake()
    {
        m = this;
        // mus = GetComponentsInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (c == 1)
        {
            //Sons(1, 1);
            Sons(0,0);
            c = 0;
        }
    }

    public void Sons(int s,int s1)
    {
        mus[s1].clip = sons[s];
        mus[s1].Play();

    }
    
}
