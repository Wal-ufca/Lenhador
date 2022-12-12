using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ItemBox : MonoBehaviour
{
    public int live;
    public float walkTime;
    private float timer;
    public GameObject itens;
    public GameObject box;

    private void Update()
    {
        if(live == 0)
        {
            Item();
        }
    }

    public void Damage()
    {
        live = 0;
        //collision.gameObject.GetComponent<Player>().IncreaseLife(healtVolue);
        box.SetActive(false);
        itens.SetActive(true);
    }

    void Item()
    {
        timer += Time.deltaTime;
        if (timer >= walkTime)
        {
            itens.SetActive(false);
            live = 1;
        }
    }

    public void Life()
    {
        Player.p.IncreaseLife(2);

        //GameControl.instance.UpdadeLives(Player.p.health);
    }

    public int Vel(int x)
    {
        //Mus.m.Sons(9, 2);
        // Player.p.speed += 3;
        return x;
    }

    public void Forca()
    {
        Mus.m.Sons(10, 2);
        //Weapon.w.damage += 2;
        Player.p.jumpForce += 2;
    }
}
