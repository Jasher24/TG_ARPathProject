using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class SetNavigationTarget : MonoBehaviour
{

    [SerializeField]
    private TMP_Dropdown navigationTargetDropDown;
    [SerializeField]
    private TMP_Text ubicationText;
    private QrCodeRecenter qrCodeRecenter;
    [SerializeField]
    private List<Target> navigationTargetObjects = new List<Target>();
    private string selectedText = "";

    private NavMeshPath path;
    private LineRenderer line;
    private Vector3 targetPosition = Vector3.zero;
    private Target currentTarget;
    private bool lineToggle = true;

    private void Start()
    {
        qrCodeRecenter = GameObject.FindObjectOfType<QrCodeRecenter>();
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        line.enabled = lineToggle;
    }
    
    private void Update()
    {
        if (lineToggle && targetPosition != Vector3.zero)
        {
            NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path); 
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);
        }
    }
    public void ToogleVisibility()
    {
        line.enabled = lineToggle;
    }

    public void SetCurrentNavigationTarget(int selectedValue)
    {
        targetPosition = Vector3.zero;
        selectedText = navigationTargetDropDown.options[selectedValue].text;
        Debug.Log("SElected value --> " + selectedValue);
        //currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals(selectedText.ToLower()));
        
        ConditionsFloor();
    }

    public void ConditionsFloor()
    {
        if (selectedText.Equals(""))
        {
            Debug.Log("si");
        }
        if (selectedText.Equals("Salón 1"))
        {
            ubicationText.text = "Piso 2";
            if (qrCodeRecenter.changeFloor == false)
            {
                currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals("EscalerasArriba".ToLower()));
                targetPosition = currentTarget.PositionObject.transform.position;
            }
            else if (qrCodeRecenter.changeFloor == true)
            {
                SecondFloor();
            }
        }
        if (selectedText.Equals("Salón 2"))
        {
            ubicationText.text = "Piso 2";
            if (qrCodeRecenter.changeFloor == false)
            {
                currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals("EscalerasArriba".ToLower()));
                targetPosition = currentTarget.PositionObject.transform.position;
            }
            else if (qrCodeRecenter.changeFloor == true)
            {
                SecondFloor();
            }
        }
        if (selectedText.Equals("Salón 3"))
        {
            ubicationText.text = "Piso 2";
            if (qrCodeRecenter.changeFloor == false)
            {
                currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals("EscalerasArriba".ToLower()));
                targetPosition = currentTarget.PositionObject.transform.position;
            }
            else if (qrCodeRecenter.changeFloor == true)
            {
                SecondFloor();
            }
        }
        if (selectedText.Equals("Salón 4"))
        {
            ubicationText.text = "Piso 2";
            if (qrCodeRecenter.changeFloor == false)
            {
                currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals("EscalerasArriba".ToLower()));
                targetPosition = currentTarget.PositionObject.transform.position;
            }
            else if (qrCodeRecenter.changeFloor == true)
            {
                SecondFloor();
            }
        }
        if (selectedText.Equals("Salón 5"))
        {
            ubicationText.text = "Piso 2";
            if (qrCodeRecenter.changeFloor == false)
            {
                currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals("EscalerasArriba".ToLower()));
                targetPosition = currentTarget.PositionObject.transform.position;
            }
            else if (qrCodeRecenter.changeFloor == true)
            {
                SecondFloor();
            }
        }
        if (selectedText.Equals("Sala de Sistemas"))
        {
            ubicationText.text = "Piso 2";
            if (qrCodeRecenter.changeFloor == false)
            {
                currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals("EscalerasArriba".ToLower()));
                targetPosition = currentTarget.PositionObject.transform.position;
            }
            else if (qrCodeRecenter.changeFloor == true)
            {
                SecondFloor();
            }
        }

        if (selectedText.Equals("Salón 6"))
        {
            ubicationText.text = "Piso 1";
            if (qrCodeRecenter.changeFloor == true)
            {
                currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals("EscalerasAbajo".ToLower()));
                targetPosition = currentTarget.PositionObject.transform.position;
            }
            else if(qrCodeRecenter.changeFloor == false)
            {
                SecondFloor();
            }
        }
        if (selectedText.Equals("Lab. Electronica"))
        {
            ubicationText.text = "Piso 1";
            if (qrCodeRecenter.changeFloor == true)
            {
                currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals("EscalerasAbajo".ToLower()));
                targetPosition = currentTarget.PositionObject.transform.position;
            }
            else if (qrCodeRecenter.changeFloor == false)
            {
                SecondFloor();
            }
        }
        if (selectedText.Equals("Lab. Alimentos"))
        {
            ubicationText.text = "Piso 1";
            if (qrCodeRecenter.changeFloor == true)
            {
                currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals("EscalerasAbajo".ToLower()));
                targetPosition = currentTarget.PositionObject.transform.position;
            }
            else if (qrCodeRecenter.changeFloor == false)
            {
                SecondFloor();
            }
        }
        if (selectedText.Equals("Biblioteca"))
        {
            ubicationText.text = "Piso 1";
            if (qrCodeRecenter.changeFloor == true)
            {
                currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals("EscalerasAbajo".ToLower()));
                targetPosition = currentTarget.PositionObject.transform.position;
            }
            else if (qrCodeRecenter.changeFloor == false)
            {
                SecondFloor();
            }
        }    
    }

    public void SecondFloor()
    {
        currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals(selectedText.ToLower()));

        if (currentTarget != null)
        {
            targetPosition = currentTarget.PositionObject.transform.position;
            Debug.Log("selectedValue --> " + selectedText);
        }
        else
        {
            Debug.Log("currentTarget = null");
        }
    }

    
}
