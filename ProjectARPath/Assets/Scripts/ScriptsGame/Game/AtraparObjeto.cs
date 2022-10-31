using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AtraparObjeto : MonoBehaviour
{
    [SerializeField]
    private GameObject imageWin;
    [SerializeField]
    private GameObject objeto;
    [SerializeField]
    private GameObject buttonNextPistas;
    [SerializeField]
    private GameObject plane;
    [SerializeField]
    public GameObject panelSenales;

    private GameManager gameManager = null;
    public Counter counter;
    public int number;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    public void OnMouseDown()
    {
        objeto.SetActive(false);
        panelSenales.SetActive(false);
        buttonNextPistas.SetActive(true);
        plane.SetActive(true);
        gameManager.PlaySound();
        //gameManager.DesactiveTarget();

        //puntaje = int.Parse(gameManager.puntuacion.text) + int.Parse(gameManager.monedas.text);
        //counter.puntos += puntaje;

        //Envia el estado de ImagenWin al counter
        if (number == 1)
        {
            counter.image1 = true;
        }
        else if (number == 2)
        {
            counter.image2 = true;
        }
        else if (number == 3)
        {
            counter.image3 = true;
        }
        else if (number == 4)
        {
            counter.image4 = true;
        }
        else if (number == 5)
        {
            counter.image5 = true;
        }
       
    }
}
