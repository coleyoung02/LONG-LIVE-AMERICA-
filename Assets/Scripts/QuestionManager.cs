using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] private List<MessageSO> questions;
    [SerializeField] private TextMeshProUGUI tm;
    [SerializeField] private float charLength;
    [SerializeField] private float questionResponseTime;
    private string activeQuestionText;
    private string activeQuestionCategory;
    private bool respondable;
    private float expectedLength;
    private int questionIndex;
    private float charClock;
    private float questionClock;

    // Start is called before the first frame update
    void Start()
    {
        questions = questions.OrderBy(x => UnityEngine.Random.value).ToList();
        questionIndex = 0;
        PopulateNextQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        if (!respondable)
        {
            tm.text = activeQuestionText.Substring(0, Mathf.Min(Mathf.RoundToInt(activeQuestionText.Length * charClock / expectedLength), activeQuestionText.Length));
            charClock += Time.deltaTime;
            if (tm.text.Length == activeQuestionText.Length)
            {
                respondable = true;
                questionClock = questionResponseTime;
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
                PopulateNextQuestion();
            }
        }
    }

    private void PopulateNextQuestion()
    {
        if (questionIndex < questions.Count)
        {
            activeQuestionText = questions[questionIndex].message;
            activeQuestionCategory = questions[questionIndex].category;
            ++questionIndex;
            expectedLength = charLength * activeQuestionText.Length;
            charClock = 0f;
            respondable = false;
        }
        else
        {
            Debug.Log("fuck");
        }
    }

    public string GetActiveCategory()
    {
        return activeQuestionCategory;
    }

    public bool PlayerCanRespond()
    {
        return respondable;
    }
}
