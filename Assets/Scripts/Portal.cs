using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private Animator anim;
    public static Portal por;
    //public GameObject jogador;
    public int aparece = 1;
    public int level;
    private float t;
    public float ta;
    public GameObject seta;
    Transform player;
    public bool s;

    // Start is called before the first frame update
    void Awake()
    {
       anim = GetComponent<Animator>();
        por = this;
        //salvanda as "cordenadas" do objeto player em player
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(aparece == 0)
        {
            Animar(level);
            seta.SetActive(true);
        }
        Seta(seta.transform.position.x, 32.6);//
    }
    private void LateUpdate()
    {
        if (/*player.position.x >= -3 &&*/ player.position.x <= 28)
        {
            //cria uma variavel com a posicao x do personagem e y e z da camera
            Vector3 following = new Vector3(player.position.x + 6, player.position.y, seta.transform.position.z);

            //atualizando posicao da camera
            seta.transform.position = following;
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

    public void Seta(double xp,double xm)
    {
        if(xp > xm)//32.6
        {
            seta.SetActive(false);
            s = false;

        }
        else
        {
            seta.SetActive(true);
            s= true;
        }
    }
}
