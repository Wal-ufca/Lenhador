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
    public int scoreVolue;

    private bool cortada;

    // Start is called before the first frame update
    void Start()
    {
       // rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
   /* void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= walkTime)
        {
            walkRight = !walkRight;
            timer = 0f;
        }

        if (walkRight)
        {
            transform.eulerAngles = new Vector2(0, 180);
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 0);
            rig.velocity = Vector2.left * speed;
        }
    }
   */

    //dano que o enemy vaoi receber ddo player
    public void Damage(int dmg)
    {
        health -= dmg;

        //coferir se o enemy ainda tem vida
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
            
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameControl.instance.UpdateScore(scoreVolue);
            Destroy(gameObject);
        }
    }

     private void OnCollisionEnter2D(Collision2D collision)
     {

         if (collision.gameObject.tag == "Arma")
         {
             collision.gameObject.GetComponent<Player>().Damage(damage);
         }
     }*/
}
