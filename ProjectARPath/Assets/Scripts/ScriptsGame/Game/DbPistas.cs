using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DbPistas : MonoBehaviour
{
    [SerializeField]
    private List<Pista> pistasList = null;
    private List<Pista> m_backup = null;

    private void Awake()
    {
        m_backup = pistasList.ToList();
    }

    public Pista GetRandom(bool remove = true)
    {
        if (pistasList.Count == 0)
            RestoreBackup();            

        int index = Random.Range(0, pistasList.Count);
        if (!remove)
            return pistasList[index];

        Pista p = pistasList[index];
        pistasList.RemoveAt(index);

        return p;
    }

    public void RestoreBackup()
    {
        pistasList = m_backup.ToList();
    }
}
