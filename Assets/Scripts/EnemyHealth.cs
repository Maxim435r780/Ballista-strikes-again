using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float HP = 100;
    public float DeathTimer = 2.5f;
    public AudioSource AudioDeath;

    [SerializeField] private Animator _animator;

    private float HPPrevFrame ;
    private int i = 0;

    private void Start()
    {
        HPPrevFrame = HP - 1;
    }

    void Update()
    {
        if (HP < HPPrevFrame)
        {
            _animator.SetTrigger("Hit");
            var audHit = gameObject.GetComponent<AudioSource>();
            if (HP > 0)
            {
                audHit.Play();
            }
        }

        if ((HP <= 0) && (i == 0))
        {
            _animator.SetTrigger("Dead");
            deathTimerMethod();
            AudioDeath.Play();
            i = 1;
        }
        HPPrevFrame = HP;
    }
    private void deathTimerMethod()
    {
        Invoke("DestrEne", DeathTimer);
        var AI = gameObject.GetComponent<EnemyAI>();
        AI.DeadInt = 1;
    }
    private void DestrEne()
    {
        Destroy(gameObject);
    }
}
