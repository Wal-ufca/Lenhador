using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySnake : MonoBehaviour
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
    //public bool enemy;
    //public int boss;
    //public GameObject dominio;
    public static EnemySnake es;
    //public GameObject portal;
    public bool snake = true;

    // Start is called before the first frame update
    void Start()
    {
        es = this;
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

    //dano que o enemy vaoi receber ddo player
    public void Damage(int dmg)
    {
        health -= dmg;
        //anim.SetTrigger("hit");

            //colidir com o inimigo faz o player ser jogado para tras
            if (transform.rotation.y == 0)
            {
                transform.position += new Vector3(0.5f, 0, 0);

            }
            else // (transform.rotation.y == 180)
            {
                transform.position += new Vector3(-0.5f, 0, 0);
            }

        //coferir se o enemy ainda tem vida
        if (health <= 0)
        {
            //Destroy(gameObject);
            DestroyImmediate(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (enemy)
        //{
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().Damage1(damage);
        }
        
    }
}
