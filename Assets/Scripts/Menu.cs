using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject inf;
    public void LoadGame()
    {
        Mus.m.Sons(1,1);
        SceneManager.LoadScene(1);
    }
    public void Inf()
    {
        Mus.m.Sons(1, 1);
        inf.SetActive(true);
        //Mus.m.Sons(1);
    }

    public void Voltar()
    {
        Mus.m.Sons(1, 1);
        inf.SetActive(false);
        //SceneManager.LoadScene(0);
    }

    public void Sair()
    {
        Mus.m.Sons(1, 1);
        Application.Quit();
    }
}
