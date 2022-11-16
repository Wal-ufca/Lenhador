using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Domain : MonoBehaviour
{
    public int damage;
    public float walkTime;
    private float timer;
    private int speedMax = 1;

    /*private void OnTriggerEnter2D(Collider2D collision)
    {

            if (collision.gameObject.tag == "Player")
            {
                collision.GetComponent<Player>().DmgSpeed(1);
            }
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        timer += Time.deltaTime;
        if (timer >= walkTime)
        {
            timer = 0;

            if (collision.gameObject.tag == "Player")
            {
                Player.p.Damage(damage);
                //Destroy(gameObject);
                //speedMax -= 1;
            }
        }
        if (speedMax == 1)
        {
            Player.p.DmgSpeed(3);
            Player.p.Damage(0);
            speedMax = 2;
        }
    }

}
