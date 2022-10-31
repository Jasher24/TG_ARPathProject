using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Almacena todas las preguntas (Base de Datos)

public class DbQuestion : MonoBehaviour
{
    [SerializeField]
    private List<Question> questionList = null;
    private List<Question> m_backup = null;

    private void Awake()
    {
        m_backup = questionList.ToList();
    }

    public Question GetRandom(bool remove = true)
    {
        if(questionList.Count == 0)
            RestoreBackup();

        int index = Random.Range(0, questionList.Count);

        if (!remove)
            return questionList[index];

        Question q = questionList[index];
        questionList.RemoveAt(index);

        return q;
    }

    private void RestoreBackup()
    {
        questionList = m_backup.ToList();
    }

}
