using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    private AudioSource audioSource;
    public AudioClip menuSound;
    public AudioClip pickupSound;
    public AudioClip groundFootStepSound;
    public AudioClip rockFootStepSound;
    public AudioClip dashSound;
    public AudioClip stoneSlideSound;
    public AudioClip gulpSound;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void playMenuSFX()
    {
        audioSource.PlayOneShot(menuSound);
    }

    public void playPickupSFX()
    {
        audioSource.PlayOneShot(pickupSound);
    }

    public void playGroundFootStepSFX()
    {
        audioSource.PlayOneShot(groundFootStepSound);
    }

    public void playRockFootStepSFX()
    {
        audioSource.PlayOneShot(rockFootStepSound);
    }

    public void playDashSFX()
    {
        audioSource.PlayOneShot(dashSound, 0.3f);
    }

    public void playStoneSlideSFX()
    {
        audioSource.PlayOneShot(stoneSlideSound);
    }

    public void playGulpSFX()
    {
        audioSource.PlayOneShot(gulpSound);
    }
}
