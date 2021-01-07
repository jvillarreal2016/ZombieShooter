using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    PlayerHealth target; //make target of type PlayerHealth because Unity isn't a fan of dragging instances if not through code
    [SerializeField] float damage = 40f;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>(); //don't put FOOT (lol) in Update method, keep it in Start
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        target.TakeDamge(damage);
        target.GetComponent<DisplayDamage>().ShowDamageCanvas();
    }
}
