using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Message", menuName = "Messages")]
public class MessageSO : ScriptableObject
{
    public string message;
    public string category;
}
