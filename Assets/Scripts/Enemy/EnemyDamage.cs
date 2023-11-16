using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerComponent))
        {
            playerComponent.TakeDamage(1);

        }
    }
}
