using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResponseButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tm;
    [SerializeField] private ResponseManager rm;
    [SerializeField] private List<AudioClip> sfxClips;
    [SerializeField] private AudioSource audioSource;  
    private string category;

    public void OnPress()
    {
        if (rm.TryCategory(category))
        {
            PlayRandomSFX();
        }
    }

    public void SetMessage(MessageSO m)
    {
        tm.text = m.message;
        category = m.category;
    }

    private void PlayRandomSFX()
    {
        if (sfxClips.Count > 0)
        {
            int randomIndex = Random.Range(0, sfxClips.Count);
            AudioClip randomClip = sfxClips[randomIndex];
            audioSource.PlayOneShot(randomClip);
        }
    }
}
