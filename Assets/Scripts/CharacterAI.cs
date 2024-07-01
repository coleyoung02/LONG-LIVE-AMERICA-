using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAI : CharacterManager
{
    [SerializeField] private List<MessageSO> messages;
    [SerializeField] private float responseDelay;
    [SerializeField] private float responseDelayVariance;
    private QuestionManager qm;
    private float responseClock;


    protected override void Start()
    {
        base.Start();
        qm = FindAnyObjectByType<QuestionManager>();
        ResetResponseClock();
    }

    private void ResetResponseClock()
    {
        responseClock = responseDelay + UnityEngine.Random.Range(-responseDelayVariance / 2f, responseDelayVariance / 2f);
    }

    private void Update()
    {
        if (qm.PlayerCanRespond())
        {
            responseClock -= Time.deltaTime;

            if (responseClock <= 0)
            {
                MessageSO response = messages[Random.Range(0, messages.Count)];
                TryMessage(response);
                ResetResponseClock();
            }
        }
    }

    private void TryMessage(MessageSO m)
    {
        if (m.category.Equals(qm.GetActiveCategory()))
        {
            OnFail(m.message);
        }
        else
        {
            OnSuccess(m.message);
        }
    }
}
