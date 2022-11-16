using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    //public float walkTime;
    public int health;
    //public int damage;

   // private float timer;
    //private bool walkRight = true;
    //private Rigidbody2D rig;
    private Animator anim;

    public GameObject snake;
    public GameObject bat;
    public GameObject bat2;
    public GameObject arv;
    public int scoreVolue;

    private bool cortada;

    // Start is called before the first frame update
    void Start()
    {
       // rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //dano que o enemy vaoi receber ddo player
    public void Damage(int dmg)
    {
        health -= dmg;

        //coferir se o enemy ainda tem vida
        //cortada para nao gerar um monte de inimigos
        if (health <= 0 && !cortada)
        {
            anim.SetTrigger("Cortada");
            cortada = true;
            if (GameControl.instance.score == 0)
            {
                //Destroy(gameObject);
               // anim.SetTrigger("Cortada");
                GameControl.instance.UpdateScore(scoreVolue);
                snake.SetActive(true);
            }
            else if (GameControl.instance.score == 1)
            {
                GameControl.instance.UpdateScore(scoreVolue);
                bat.SetActive(true);
            }
            else if(GameControl.instance.score == 2)
            {
                GameControl.instance.UpdateScore(scoreVolue);
                bat2.SetActive(true);
            }
            else if(GameControl.instance.score == 3)
            {
                GameControl.instance.UpdateScore(scoreVolue);
                arv.SetActive(true);
            }
            
        }
    }
}
