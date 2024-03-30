using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDAudioWeels : MonoBehaviour
{
    public AudioSource AudioWeels;
    private bool IsPlayingSound = false;
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            if (!IsPlayingSound)
            {
                AudioWeels.Play();
                IsPlayingSound = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            AudioWeels.Stop();
            IsPlayingSound = false;
        }
        if (Input.GetKeyUp(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.S))
        {
            AudioWeels.Stop();
            IsPlayingSound = false;
        }
        if (Input.GetKeyUp(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S))
        {
            AudioWeels.Stop();
            IsPlayingSound = false;
        }
        if (Input.GetKeyUp(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            AudioWeels.Stop();
            IsPlayingSound = false;
        }
    }
}
