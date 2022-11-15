using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHeart : MonoBehaviour
{
    public int healtVolue;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Mus.m.Sons(6, 3);
            collision.gameObject.GetComponent<Player>().IncreaseLife(healtVolue);
            Destroy(gameObject);
        }
    }
}
