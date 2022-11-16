using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniMenu : MonoBehaviour
{
    public float speed;
    private bool walkRight = true;
    private Rigidbody2D rig;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        Limitacao();

    }

    void Limitacao()
    {
        anim.SetInteger("transition", 1);
        if (transform.position.x <= -8.5 || transform.position.x >= 8.5)
        {
            anim.SetInteger("transition", 3);
            walkRight = !walkRight;

        }

        if (walkRight)
        {
            transform.eulerAngles = new Vector2(0, 0);
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
            rig.velocity = Vector2.left * speed;
        }
    }
}
