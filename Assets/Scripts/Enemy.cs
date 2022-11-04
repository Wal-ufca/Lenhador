using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;
    //public float walkTime;
    public int health;
    public int damage;

    //private float timer;
    //private bool walkRight = true;
    private Rigidbody2D rig;
    private Animator anim;

    private Transform p_player;
    public bool enemy;
    public bool boss;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //salvanda as "cordenadas" do objeto player em player
        p_player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

    }

    void Move()
    {
        if (enemy)
        {
            if (p_player.position.y < 2)
            {
                if (p_player.position.x > gameObject.transform.position.x)
                {
                    transform.eulerAngles = new Vector2(0, 180);
                    rig.velocity = Vector2.right * speed;
                }
                else if (p_player.position.x < gameObject.transform.position.x)
                {
                    transform.eulerAngles = new Vector2(0, 0);
                    rig.velocity = Vector2.left * speed;
                }
            }
        }
        else
        {
            if (p_player.position.x > gameObject.transform.position.x)
            {
                //transform.eulerAngles = new Vector2(0, 180);
                rig.velocity = new Vector2(1 * speed, rig.velocity.y);
            }
            else if (p_player.position.x < gameObject.transform.position.x)
            {
                //transform.eulerAngles = new Vector2(0, 0);
                rig.velocity = new Vector2(-1 * speed, rig.velocity.y);
            }

            if (p_player.position.y > gameObject.transform.position.y)
            {
                rig.velocity = new Vector2(rig.velocity.x, 1 * speed);

            }
            else if (p_player.position.y < gameObject.transform.position.y)
            {
                rig.velocity = new Vector2(rig.velocity.x, -1 * speed);
            }
        }
    }

    //dano que o enemy vaoi receber ddo player
    public void Damage(int dmg)
    {
        health -= dmg;
        anim.SetTrigger("hit");

        //coferir se o enemy ainda tem vida
        if (health <= 0)
        {
            Destroy(gameObject);

            if(boss)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (enemy)
        //{
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Player>().Damage(damage);
            }
        //}
        /*else
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Player>().Damage(damage);

                //colidir com o inimigo faz o player ser jogado para tras
                if (transform.rotation.y == 180)
                {
                    transform.position += new Vector3(1f, 0, 0);

                }
                else // (transform.rotation.y == 180)
                {
                    transform.position += new Vector3(1f, 0, 0);
                }
            }
        }*/
    }
}
