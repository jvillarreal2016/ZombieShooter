using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealths : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamge(float damage)
    {
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

}
