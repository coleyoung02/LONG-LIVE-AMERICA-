using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResponseManager : MonoBehaviour
{
    [SerializeField] private List<ResponseButton> buttons;
    [SerializeField] private List<MessageSO> responses;
    [SerializeField] private QuestionManager qm;
    [SerializeField] private CharacterManager cm;

    private void Start()
    {
        ResetButtons();
    }

    private void Update()
    {
        
    }

    private void ResetButtons()
    {
        responses = responses.OrderBy(x => UnityEngine.Random.value).ToList();
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetMessage(responses[i]);
        }
    }

    public void TryCategory(string c)
    {
        if (!qm.PlayerCanRespond())
        {
            return;
        }
        else
        {
            ResetButtons();
            if (qm.GetActiveCategory().Equals(c))
            {
                cm.OnFail("");
            }
            else
            {
                cm.OnSuccess("");
            }
        }
    }
}
