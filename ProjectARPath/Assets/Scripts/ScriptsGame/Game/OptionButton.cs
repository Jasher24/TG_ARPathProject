using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]

public class OptionButton : MonoBehaviour
{
    private TMP_Text m_text = null;
    private Button button = null;
    private Image image = null;
    private Color originalColor = Color.black;

    public Option Option { get; set; }

    private void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        m_text = transform.GetChild(0).GetComponent<TMP_Text>();

        originalColor = image.color;
    }

    public void Construtc(Option option, Action<OptionButton> callback)
    {
        m_text.text = option.text;

        button.onClick.RemoveAllListeners();
        button.enabled = true;
        image.color = originalColor;

        Option = option;

        button.onClick.AddListener(delegate
        {
            callback(this);
        });
    }

    public void SetColor(Color c)
    {
        button.enabled = false;
        image.color = c;
    }
    
}
