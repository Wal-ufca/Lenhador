using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private Animator anim;
    public static Portal por;
    public GameObject jogador;
    public int aparece = 1;
    public int level;
    private float t;
    public float ta;

    // Start is called before the first frame update
    void Awake()
    {
       anim = GetComponent<Animator>();
        por = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(aparece == 0)
        {
            Animar(level);
        }
    }

    public void Animar( int lv)
    {
        //Mus.m.Sons(8,4);
        t += Time.deltaTime;
        anim.SetInteger("transition", 1);
        
        if (t > ta )
        {
            //Mus.m.Sons(8,4);
            if (lv == 1)
            {
                //jogador.SetActive(false);
                SceneManager.LoadScene(2);
            }
            else if(lv == 2)
            {
                GameControl.instance.End();
            }
            aparece = 1;
        }

    }
}
