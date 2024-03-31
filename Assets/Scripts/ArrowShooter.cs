using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    public Arrow Projectile;
    public Transform ArrowSourceTransform;
    public float mouseHeldDownTime = 0.15f;

    private float t = 0;

    void Update()
    {
        t = t + (1 * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Projectile, ArrowSourceTransform.position, ArrowSourceTransform.rotation);
            t = 0;
        }

        if (Input.GetMouseButton(0))
        {
            if (t > mouseHeldDownTime)
            {
                Instantiate(Projectile, ArrowSourceTransform.position, ArrowSourceTransform.rotation);
                t = 0;
            }
        }
    }
}
