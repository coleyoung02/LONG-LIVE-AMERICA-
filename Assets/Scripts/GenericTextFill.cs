using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenericTextFill : MonoBehaviour
{
    [SerializeField] private string text;
    [SerializeField] private TextMeshProUGUI tm;
    [SerializeField] private float charLength;
    [SerializeField] private float questionResponseTime;
    [SerializeField] private AudioSource typeSFX;
    [SerializeField] private AudioSource dingSFX;
    private float expectedLength;
    private int questionIndex;
    private float charClock;
    private float questionClock;
    private bool doneTyping;



    // Start is called before the first frame update
    void Start()
    {
        questionIndex = 0;
        doneTyping = false;
        PopulateNextQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        if (!doneTyping)
        {
            tm.text = text.Substring(0, Mathf.Min(Mathf.RoundToInt(text.Length * charClock / expectedLength), text.Length));
            charClock += Time.deltaTime;
            if (tm.text.Length == text.Length)
            {
                doneTyping = true;
                questionClock = questionResponseTime;
                typeSFX.Stop();
                dingSFX.Play();

            }
        }
        else
        {
            if (questionClock > 0)
            {
                questionClock -= Time.deltaTime;
            }
            if (questionClock <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    private void PopulateNextQuestion()
    {
        expectedLength = charLength * text.Length;
        charClock = 0f;
        doneTyping = false;
        typeSFX.Play();
    }
}
