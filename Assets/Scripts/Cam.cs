using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Transform player;
    public float smooth;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //delimitar o movimento da tela pra nao sair do mapa
        if (player.position.x >= -0.5)
        {
            //cria uma variavel com a posicao x do personagem e y e z da camera
            Vector3 following = new Vector3(player.position.x, transform.position.y, transform.position.z);

            //atualizando posicao da camera
            transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime);
        }
    }
}
