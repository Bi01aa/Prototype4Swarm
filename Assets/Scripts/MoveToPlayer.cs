using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform Player;
    public float SpaceBetween = 1.5f;

    void Update()
    {
        if (Vector3.Distance(Player.position, transform.position) >= SpaceBetween)
        {
            Vector3 direction = Player.position - transform.position;
            transform.Translate(direction * Time.deltaTime);
        }
        
    }
}
