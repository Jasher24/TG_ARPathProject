using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkConsultas : MonoBehaviour
{

    public void linkConsultas(string Url)
    {
        Application.OpenURL(Url);
    }
}
