using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Sonido
    [SerializeField]
    private AudioClip m_correctSound = null;
    [SerializeField]
    private AudioClip m_incorrecSound = null;
    [SerializeField]
    private AudioClip m_GameOverSound = null;
    [SerializeField]
    private AudioClip m_GameWinSound = null;
    [SerializeField]
    private AudioClip m_selectObjectSound = null;
    //Color
    [SerializeField]
    private Color m_correctColor = Color.black;
    [SerializeField]
    private Color m_incorrectColor = Color.black;
    [SerializeField]
    private float m_waitTime = 0.0f;
    //Controles
    [SerializeField]
    public TMP_Text puntuacion = null;
    [SerializeField]
    public TMP_Text monedas = null;
    [SerializeField]
    private GameObject imageWin1;
    [SerializeField]
    private GameObject imageWin2;
    [SerializeField]
    private GameObject imageWin3;
    [SerializeField]
    private GameObject imageWin4;
    [SerializeField]
    private GameObject imageWin5;
  
    [SerializeField]
    private GameObject panelOptions;
    [SerializeField]
    private GameObject panelPistas;
    [SerializeField]
    public GameObject panelSenales;
    [SerializeField]
    private GameObject buttonNextPistas;
    [SerializeField]
    private GameObject planeVideo;
    [SerializeField]
    private GameObject planeColiseo;
    [SerializeField]
    private GameObject planeCafeteria;
    [SerializeField]
    private GameObject buttonAgain;
    [SerializeField]
    private GameObject cuboQuestion1;
    [SerializeField]
    private GameObject cuboQuestion2;
    [SerializeField]
    private GameObject cuboQuestion3;
    [SerializeField]
    private GameObject cuboQuestion4;
    [SerializeField]
    private GameObject cuboQuestion5;

    [SerializeField]
    private GameObject objeto1;
    [SerializeField]
    private GameObject objeto2;
    [SerializeField]
    private GameObject objeto3;
    [SerializeField]
    private GameObject objeto4;
    [SerializeField]
    private GameObject objeto5;

    public Counter counter;
    private DbQuestion dbQuestion = null;
    private UIQuestion uIQuestion = null;
    private AudioSource audioSource = null;
    private DbPistas dbPistas = null;
    private UIPistas uIPistas = null;
    int puntaje = 0;

    private bool estado = true;

    private void Start()
    {
        dbQuestion = GameObject.FindObjectOfType<DbQuestion>();
        uIQuestion = GameObject.FindObjectOfType<UIQuestion>();
        audioSource = GetComponent<AudioSource>();
        dbPistas = GameObject.FindObjectOfType<DbPistas>();
        uIPistas = GameObject.FindObjectOfType<UIPistas>();
        NextPista();
    }
    private void Update()
    {
        puntuacion.text = counter.puntos.ToString();
        imageWin1.SetActive(counter.image1);
        imageWin2.SetActive(counter.image2);
        imageWin3.SetActive(counter.image3);
        imageWin4.SetActive(counter.image4);
        imageWin5.SetActive(counter.image5);
    }
    private void NextPista()
    {
        uIPistas.Construtc(dbPistas.GetRandom());
        NextQuestion();
    }
    private void NextQuestion()
    {
        uIQuestion.Construtc(dbQuestion.GetRandom(), GiveAnswer);
    }
    private void GiveAnswer(OptionButton optionButton)
    {
        StartCoroutine(GiveAnswerRoutine(optionButton));
    }
    private IEnumerator GiveAnswerRoutine(OptionButton optionButton)
    {
        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.clip = optionButton.Option.correct ? m_correctSound : m_incorrecSound;
        optionButton.SetColor(optionButton.Option.correct ? m_correctColor : m_incorrectColor);
        puntaje += optionButton.Option.correct ? 15 : -5;
        monedas.text = puntaje.ToString();

        audioSource.Play();

        yield return new WaitForSeconds(m_waitTime);

        NextQuestion();
    }

    public void LineTimer()
    {
        if (puntaje >= 40)
        {
            estado = false;
            StatePanelOptions(1);
            panelSenales.SetActive(true);
            cuboQuestion1.SetActive(false);
            objeto1.SetActive(uIPistas.objeto1);
            cuboQuestion2.SetActive(false);
            objeto2.SetActive(uIPistas.objeto2);
            cuboQuestion3.SetActive(false);
            objeto3.SetActive(uIPistas.objeto3);
            cuboQuestion4.SetActive(false);
            objeto4.SetActive(uIPistas.objeto4);
            cuboQuestion5.SetActive(false);
            objeto5.SetActive(uIPistas.objeto5);
            counter.puntos += puntaje;
            PlaySound(true);
        }
        else
        {
            PlaySound(false);
            estado = false;
            StatePanelOptions(1);
            cuboQuestion1.SetActive(false);
            cuboQuestion2.SetActive(false);
            cuboQuestion3.SetActive(false);
            cuboQuestion4.SetActive(false);
            cuboQuestion5.SetActive(false);
            buttonAgain.SetActive(true);
            DesactiveTarget();
        }
    }
    public void ButtonAgain()
    {
        buttonAgain.SetActive(false);
        panelPistas.SetActive(true);
        panelSenales.SetActive(false);
        cuboQuestion1.SetActive(true);
        cuboQuestion2.SetActive(true);
        cuboQuestion3.SetActive(true);
        cuboQuestion4.SetActive(true);
        cuboQuestion5.SetActive(true);
        objeto1.SetActive(false);
        objeto2.SetActive(false);
        objeto3.SetActive(false);
        objeto4.SetActive(false);
        objeto5.SetActive(false);
        estado = true;
        uIPistas.ActivateTarget();
    }
    public void ButtonPistas()
    {
        buttonNextPistas.SetActive(false);
        panelPistas.SetActive(true);
        panelSenales.SetActive(false);
        planeVideo.SetActive(false);
        planeColiseo.SetActive(false);
        planeCafeteria.SetActive(false);
        cuboQuestion1.SetActive(true);
        cuboQuestion2.SetActive(true);
        cuboQuestion3.SetActive(true);
        cuboQuestion4.SetActive(true);
        cuboQuestion5.SetActive(true);
        objeto1.SetActive(false);
        objeto2.SetActive(false);
        objeto3.SetActive(false);
        objeto4.SetActive(false);
        objeto5.SetActive(false);
        puntaje = 0;
        monedas.text = "0";
        estado = true;
        NextPista();
    }
    public void StatePanelOptions(int n)
    {
        if(n == 1)
        {
            panelOptions.SetActive(estado);
        }
        else if(n == 2)
        {
            panelOptions.SetActive(false);
        }
        
    }
    
    private void PlaySound(bool state)
    {
        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.clip = state ? m_GameWinSound : m_GameOverSound;
        audioSource.Play();
    }
    public void PlaySound()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.clip = m_selectObjectSound;
        audioSource.Play();
    }
    public void DesactiveTarget()
    {
        uIPistas.target1.SetActive(false);
        uIPistas.target2.SetActive(false);
        uIPistas.target3.SetActive(false);
        uIPistas.target4.SetActive(false);
        uIPistas.target5.SetActive(false);
    }
}
