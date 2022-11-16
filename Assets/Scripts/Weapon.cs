using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //private Rigidbody2D rig;
    public float speed;
    public int damage ;

    public bool isRight;
    public static Weapon w;

    private void Awake()
    {
        w = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //rig = GetComponent<Rigidbody2D>();
        Mus.m.Sons(2, 2);
        //destruir o machado depois de um certo tempo
        Destroy(gameObject, 0.25f);

    }


    //dano que o machado faz ao colidir com o enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Mus.m.Sons(4, 2);
            collision.GetComponent<Enemy>().Damage(damage);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Arvore")
        {
            Mus.m.Sons(3, 2);
            collision.GetComponent<Tree>().Damage(damage);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Item")
        {
            collision.GetComponent<ItemBox>().Damage();
        }
    }
}
