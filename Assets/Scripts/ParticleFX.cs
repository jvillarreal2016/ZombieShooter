using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFX : MonoBehaviour
{
    private ParticleSystem ps;
    public PlaneController pc;
    public float particleSpeed;
    float bulletSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        GameObject plane = GameObject.Find("Airplane");
        PlaneController planeController = plane.GetComponent<PlaneController>();
        planeController.speed = particleSpeed;
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        BulletSpeed();
        ShootBullets();
    }

    private void BulletSpeed()
    {
        ParticleSystem.MainModule getParticleSpeed = ps.main;
        getParticleSpeed.simulationSpeed = particleSpeed + bulletSpeed;
    }
    void ShootBullets()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            ps.Play();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            ps.Stop();
        }
    }
}
