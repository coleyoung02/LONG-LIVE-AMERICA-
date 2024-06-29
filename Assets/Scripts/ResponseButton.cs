using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResponseButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tm;
    [SerializeField] private ResponseManager rm;
    private string category;

    public void OnPress()
    {
        rm.TryCategory(category);
    }

    public void SetMessage(MessageSO m)
    {
        tm.text = m.message;
        category = m.category;
    }
}
