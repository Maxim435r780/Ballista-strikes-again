using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 1;
    public float lifeTime = 3;
    public float damage = 10;
    void Start()
    {
        Invoke("DestrArr", lifeTime);
    }

    void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemyHPScript = other.gameObject.GetComponent<EnemyHPKostyl>();
        if (enemyHPScript != null)
        {
            enemyHPScript.value -= damage;
        }

        DestrArr();
    }

    private void DestrArr()
    {
        Destroy(gameObject);
    }

}
