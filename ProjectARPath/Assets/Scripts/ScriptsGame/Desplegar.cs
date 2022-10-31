using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desplegar : MonoBehaviour
{
    public void desplegar(GameObject boton)
    {
        if (boton.activeSelf)
        {
            boton.SetActive(false);
        }
        else if (!boton.activeSelf)
        {
            boton.SetActive(true);
        }
    }
}
