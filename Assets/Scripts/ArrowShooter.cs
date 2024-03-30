using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    public Arrow Projectile;
    public Transform ArrowSourceTransform;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Projectile, ArrowSourceTransform.position, ArrowSourceTransform.rotation);
        }
    }
}
