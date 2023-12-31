using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Vector3 firingPoint;

    [SerializeField] private float projectileSpeed;

    [SerializeField] private float maxProjectileDistance;
    
    void Start()
    {
        firingPoint = transform.position;
    }

    
    void Update()
    {
        MoveProjectile();
    }

    void MoveProjectile()
    {
        if (Vector3.Distance(firingPoint, transform.position) > maxProjectileDistance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
        }
        
    }

   

}
