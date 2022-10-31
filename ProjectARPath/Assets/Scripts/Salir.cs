using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salir : MonoBehaviour
{
    //Cambio de Escena

    public void botonAtras()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if(Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
                return;
            }
        }
    }
}
