using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UIPistas : MonoBehaviour
{
    [SerializeField]
    private TMP_Text pista = null;
    [SerializeField]
    public GameObject target1;
    [SerializeField]
    public GameObject target2;
    [SerializeField]
    public GameObject target3;
    [SerializeField]
    public GameObject target4;
    [SerializeField]
    public GameObject target5;

    public bool objeto1;
    public bool objeto2;
    public bool objeto3;
    public bool objeto4;
    public bool objeto5;

    public int number = 0;

    public void Construtc(Pista p)
    {
        pista.text = p.text;
        number = p.number;
        ActivateTarget();
    }

    public void ActivateTarget()
    {
        //Busca la pista y muestra el target correcto
        if (number == 1)
        {
            target1.SetActive(true);
            target2.SetActive(false);
            target3.SetActive(false);
            target4.SetActive(false);
            target5.SetActive(false);
            objeto1 = true;
            objeto2 = false;
            objeto3 = false;
            objeto4 = false;
            objeto5 = false;
        }
        if (number == 2)
        {
            target1.SetActive(false);
            target2.SetActive(true);
            target3.SetActive(false);
            target4.SetActive(false);
            target5.SetActive(false);
            objeto1 = false;
            objeto2 = true;
            objeto3 = false;
            objeto4 = false;
            objeto5 = false;

        }
        if (number == 3)
        {
            target1.SetActive(false);
            target2.SetActive(false);
            target3.SetActive(true);
            target4.SetActive(false);
            target5.SetActive(false);
            objeto1 = false;
            objeto2 = false;
            objeto3 = true;
            objeto4 = false;
            objeto5 = false;
        }
        if (number == 4)
        {
            target1.SetActive(false);
            target2.SetActive(false);
            target3.SetActive(false);
            target4.SetActive(true);
            target5.SetActive(false);
            objeto1 = false;
            objeto2 = false;
            objeto3 = false;
            objeto4 = true;
            objeto5 = false;

        }
        if (number == 5)
        {
            target1.SetActive(false);
            target2.SetActive(false);
            target3.SetActive(false);
            target4.SetActive(false);
            target5.SetActive(true);
            objeto1 = false;
            objeto2 = false;
            objeto3 = false;
            objeto4 = false;
            objeto5 = true;
        }
    }
}
