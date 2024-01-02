using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class EntryTrap : MonoBehaviour
{
    public GameObject bossTrap;
    public GameObject musicPlayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
            bossTrap.SetActive(true);
            StartCoroutine(waitForSound());
        }
    }

    IEnumerator waitForSound()
    {
        SoundManager.soundManager.playSandKingSFX();
        while (SoundManager.soundManager.audioSource.isPlaying)
        {
            yield return null;
        }
        musicPlayer.GetComponent<AudioSource>().Play();
    }
}
