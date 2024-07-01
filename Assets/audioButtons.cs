using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioButtons : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource buttonSFX;
    private void Start()
    {
        buttonSFX.enabled = false;
    }
    public void playButtonSound()
    {
        buttonSFX.enabled = true;
        buttonSFX.Play();
    }
}
