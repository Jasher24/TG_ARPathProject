using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class UIQuestion : MonoBehaviour
{
    [SerializeField]
    private TMP_Text m_question1 = null;
    [SerializeField]
    private TMP_Text m_question2 = null;
    [SerializeField]
    private TMP_Text m_question3 = null;
    [SerializeField]
    private TMP_Text m_question4 = null;
    [SerializeField]
    private TMP_Text m_question5 = null;

    [SerializeField]
    private List<OptionButton> m_buttonList = null;

    public void Construtc(Question q, Action<OptionButton> callback)
    {
        m_question1.text = q.text;
        m_question2.text = q.text;
        m_question3.text = q.text;
        m_question4.text = q.text;
        m_question5.text = q.text;

        for (int i = 0; i < m_buttonList.Count; i++)
        {
            m_buttonList[i].Construtc(q.options[i], callback);
        }
    }

}
