using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyComponent))
        {
            enemyComponent.TakeDamage(1);
            Debug.Log("Damage dealt");
        }
    }
}
