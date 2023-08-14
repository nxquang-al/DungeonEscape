using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip flame, gun_reload_or_click, hit01, jump, pickup, laser;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        flame = Resources.Load<AudioClip>("flame");
        gun_reload_or_click = Resources.Load<AudioClip>("gun_reload_lock_or_click_sound");
        hit01 = Resources.Load<AudioClip>("hit01");
        laser = Resources.Load<AudioClip>("laser");
        jump = Resources.Load<AudioClip>("jump");
        pickup = Resources.Load<AudioClip>("pickup");
        
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip) {
            case "flame":
                audioSrc.PlayOneShot(flame);
                break;
            case "gun_reload_or_click":
                audioSrc.PlayOneShot(gun_reload_or_click);
                break;
            case "hit01":
                audioSrc.PlayOneShot(hit01);
                break;  
            case "laser":
                audioSrc.PlayOneShot(laser);
                break;
            case "jump":
                audioSrc.PlayOneShot(jump);
                break;
            case "pickup":
                audioSrc.PlayOneShot(pickup);
                break;
            default:
                break;
        }
    }
}
