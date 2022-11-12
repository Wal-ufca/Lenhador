using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private Animator anim;
    public static Portal por;
    public GameObject jogador;
    public int aparece = 1;
    private float t;
    public float ta;

    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator>();
        por = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(aparece == 0)
        {
            Animar();
        }
    }

    public void Animar()
    {
        t += Time.deltaTime;
        Debug.Log(t);
        anim.SetInteger("transition", 1);
        if (t > ta )
        {
            jogador.SetActive(false);
            SceneManager.LoadScene(2);
            aparece = 1;
        }

    }
}
