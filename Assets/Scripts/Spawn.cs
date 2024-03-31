using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public EnemyAI Enemy;
    public GameObject OriginEnemyShell;
    public GameObject GamePlayUI;
    public GameObject UWinUI;
    public List<Transform> SpawnPoints;

    private float t = 10;
    private float t2 = 0;
    void Update()
    {
        t = t + (1 * Time.deltaTime);

        if ((t > 10 + t2) && (t2 < 8))
        {
            t = 0;
            t2++;
            for (int i = 0; i < t2; i++)
            {
                Instantiate(Enemy, SpawnPoints[i]);
            }
        }

        if (t2 > 7)
        {
            Destroy(OriginEnemyShell);
        }

        var e = GameObject.FindWithTag("Spider");
        if (e == null)
        {
            UWinUI.SetActive(true);
            GamePlayUI.SetActive(false);
            GetComponent<PlayerTPSController>().enabled = false;
            GetComponent<ArrowShooter>().enabled = false;
            GetComponent<CameraRotation>().enabled = false;
            GetComponent<WASDAudioWeels>().enabled = false;
        }

    }
}
