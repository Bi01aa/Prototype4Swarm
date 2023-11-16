using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private GameObject myTarget;
    private Transform targetPos;
    public float speed;

    void Start()
    {

        myTarget = GameObject.FindGameObjectWithTag("Player");
        targetPos = myTarget.transform;

    }

    void Update()
    {
        if (myTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
        }

        Vector3 lookVector = myTarget.transform.position - transform.position;
        lookVector.y = 0;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);

    }
}
