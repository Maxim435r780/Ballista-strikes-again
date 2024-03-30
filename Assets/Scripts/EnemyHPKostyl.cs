using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPKostyl : MonoBehaviour
{
    public EnemyHealth EnemyHealthScript;
    public float value = 1;

    private void Start()
    {
        value = EnemyHealthScript.HP;
    }

    private void Update()
    {
        EnemyHealthScript.HP = value;
    }
}
