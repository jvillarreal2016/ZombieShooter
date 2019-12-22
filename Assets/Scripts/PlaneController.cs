using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] public float speed = 90.0f;
    float maxSpeed = 250.0f;
    float minSpeed = 35.0f;
    float addedBoost = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ChaseCamera();
        
        FlyFoward();
        MaxMinFlightSpeed();

        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));

        float terrainHeightWhereWeAre = Terrain.activeTerrain.SampleHeight(transform.position);

        if (terrainHeightWhereWeAre > transform.position.y)
        {
            //todo explode when hit land/FX
            transform.position = new Vector3(transform.position.x,
                                             terrainHeightWhereWeAre,
                                             transform.position.z);
        }
    }

    private void ChaseCamera()
    {
        Vector3 moveCamTo = transform.position - transform.forward * 10.0f + Vector3.up * 5.0f;
        float bias = 0.96f;
        Camera.main.transform.position = Camera.main.transform.position * bias +
                        moveCamTo * (1.0f - bias); //spring function - further it gets, the more force it gives
        Camera.main.transform.LookAt(transform.position + transform.forward * 30.0f); //looks 30m infront of plane
    }

    private void FlyFoward()
    {
        transform.position += transform.forward * Time.deltaTime * speed;

        speed -= transform.forward.y * 50.0f;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(BoostCounter());
        }
    }

    private void MaxMinFlightSpeed()
    {
        if (speed < 35.0f)
        {
            speed = minSpeed;
        }
        if (speed > 250.0f)
        {
            speed = maxSpeed;
        }
    }

    private IEnumerator BoostCounter()
    {
        float countDown = 10f;
        for (int i = 0; i < 10000; i++)
        {
            while (countDown >= 0)
            {
                Debug.Log(i++);
                countDown -= Time.smoothDeltaTime;
                speed = speed + addedBoost;
                yield return null;
            }
        }
    }

}
