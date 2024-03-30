using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float HP = 100f;
    public AudioSource audHit;
    public RectTransform HPValueRectTransform;
    public GameObject GamePlayUI;
    public GameObject GameOverUI;

    private float MaxHP;

    private void Start()
    {
        MaxHP = HP;
        DrawHPBar();
    }

    public void DamagePlayer(float damage)
    {
        HP -= damage;

        if (!audHit.isPlaying)
        {
            audHit.Play();
        }

        if(HP <= 0)
        {
            GameOverUI.SetActive(true);
            GamePlayUI.SetActive(false);
            GetComponent<PlayerTPSController >().enabled = false;
            GetComponent<ArrowShooter>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
            GetComponent<WASDAudioWeels>().enabled = false;
            audHit.volume = 0;
        }

        DrawHPBar();

    }

    private void DrawHPBar()
    {
        HPValueRectTransform.anchorMax = new Vector2(HP / MaxHP, 1);
    }
}
