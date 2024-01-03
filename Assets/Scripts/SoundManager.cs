using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    public AudioSource audioSource;
    public AudioClip menuSound;
    public AudioClip pickupSound;
    public AudioClip groundFootStepSound;
    public AudioClip rockFootStepSound;
    public AudioClip dashSound;
    public AudioClip jumpSound;
    public AudioClip stoneSlideSound;
    public AudioClip gulpSound;
    public AudioClip slashSound1;
    public AudioClip slashSound2;
    public AudioClip hitSound;
    public AudioClip skeletonHitSound;
    public AudioClip skeletonDeathSound;
    public AudioClip sandKingSound;
    public AudioClip bossHurtSound;
    public AudioClip bossDeathSound;
    public AudioClip shieldBlockSound;

    void Awake()
    {       
        if (soundManager != null)
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
        soundManager = this;
        DontDestroyOnLoad(gameObject);
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
        audioSource.PlayOneShot(dashSound, 0.5f);
    }

    public void playDoubleJumpSFX()
    {
        audioSource.PlayOneShot(jumpSound, 0.3f);
    }

    public void playStoneSlideSFX()
    {
        audioSource.PlayOneShot(stoneSlideSound);
    }

    public void playGulpSFX()
    {
        audioSource.PlayOneShot(gulpSound, 1.5f);
    }

    public void playSlash1SFX()
    {
        audioSource.PlayOneShot(slashSound1, 0.3f);
    }

    public void playSlash2SFX()
    {
        audioSource.PlayOneShot(slashSound2, 0.3f);
    }

    public void playHitSFX()
    {
        audioSource.PlayOneShot(hitSound, 0.3f);
    }

    public void playSkeletonHitSFX()
    {
        audioSource.PlayOneShot(skeletonHitSound);
    }

    public void playSkeletonDeathSFX()
    {
        audioSource.PlayOneShot(skeletonDeathSound);
    }

    public void playSandKingSFX()
    {
        audioSource.PlayOneShot(sandKingSound);
    }
    public void playBossHurtSFX()
    {
        audioSource.PlayOneShot(bossHurtSound);
    }

    public void playBossDeathSFX()
    {
        audioSource.PlayOneShot(bossDeathSound);
    }

    public void playShieldBLockhSFX()
    {
        audioSource.PlayOneShot(shieldBlockSound);
    }
}
