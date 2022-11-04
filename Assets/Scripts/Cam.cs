using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    //transform pega as informacoes de um objeto como posicao 
    private Transform player;
    //suavidade da camera quando ela segue o player
    public float smooth;

    // Start is called before the first frame update
    void Start()
    {
        //salvanda as "cordenadas" do objeto player em player
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
