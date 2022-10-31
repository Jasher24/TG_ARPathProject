 using UnityEngine;

[CreateAssetMenu(fileName = "New Counter", menuName = "Tools/Counter", order = 0)]
public class Counter : PersistentScriptableObject
{
    //Guardar
    public float puntos = 0;
    public bool image1 = false;
    public bool image2 = false;
    public bool image3 = false;
    public bool image4 = false;
    public bool image5 = false;
}
