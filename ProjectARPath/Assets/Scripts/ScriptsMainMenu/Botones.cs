using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour{


   //Modo 1
    public void escenaIndoor()
    {
        SceneManager.LoadScene(1);
    }

    //Modo 2
    public void escenaVuforia() {

        SceneManager.LoadScene(2);
    }

    public void salir()
    {
        UnityEngine.Application.Quit();
    }
}
