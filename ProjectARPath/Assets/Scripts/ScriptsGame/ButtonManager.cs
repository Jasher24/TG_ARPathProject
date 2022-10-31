using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    private VirtualButtonBehaviour virtualButton;
    public UnityEvent OnButtonPressed;
    public UnityEvent OnButtonReleased;
    private AtraparObjeto atraparObjeto;

    private void Start()
    {
        atraparObjeto = GameObject.FindObjectOfType<AtraparObjeto>();
    }
    private void OnEnable()
    {
        virtualButton.RegisterOnButtonPressed(ButtonPressed);
        virtualButton.RegisterOnButtonReleased(ButtonReleased);
    }

    private void OnDestroy()
    {
        virtualButton.UnregisterOnButtonPressed(ButtonPressed);
        virtualButton.UnregisterOnButtonReleased(ButtonReleased);
    }

    private void ButtonPressed(VirtualButtonBehaviour button)
    {
        OnButtonPressed.Invoke();
        Debug.Log("Button Pressed");
    }

    private void ButtonReleased(VirtualButtonBehaviour button)
    {
        OnButtonReleased?.Invoke();
        Debug.Log("Button Released");
    }

    public void AtraparObjeto()
    {
        atraparObjeto.OnMouseDown();
    }
}
