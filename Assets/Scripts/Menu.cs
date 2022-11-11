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
        SceneManager.LoadScene(1);
    }
    public void Inf()
    {
        inf.SetActive(true);
    }

    public void Voltar()
    {
        inf.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
