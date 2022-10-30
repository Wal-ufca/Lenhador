using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed = 0;
    public int damage = 0;

    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        //destruir a frecha depois de um certo tempo
        Destroy(gameObject, 0.25f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRight)
        {
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            rig.velocity = Vector2.left * speed;
        }
    }

    //dano que a frecha faz ao colidir com o enemy
    /*rivate void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyGay>().Damage(damage);
            Destroy(gameObject);
        }
    }*/
}
