using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] float killParticle = .1f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
        Debug.Log("I just shot my weapon");
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealths target = hit.transform.GetComponent<EnemyHealths>();
            if (target == null) return;
            target.TakeDamge(damage);
        }
        else
        {
            return; //in case you don't hit something (the sky)
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, killParticle);
    }
}
