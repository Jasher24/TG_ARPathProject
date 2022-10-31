using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistanceManager : MonoBehaviour
{
    public List<PersistentScriptableObject> saveObject;

    private void OnEnable()
    {
        for(int i = 0; i < saveObject.Count; i++)
        {
            var so = saveObject[i];
            so.Load();
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < saveObject.Count; i++)
        {
            var so = saveObject[i];
            so.Save();
        }
    }
}
