using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn_updated : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public GameObject quad;
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        stopSpawning = false;
    }
    public void SpawnObject()
    {
        MeshCollider c = quad.GetComponent<MeshCollider>();
        float screenX, screenY;
        Vector2 pos;

        screenX = UnityEngine.Random.Range(c.bounds.min.x, c.bounds.max.x);
        screenY = UnityEngine.Random.Range(c.bounds.min.y, c.bounds.max.y);
        pos = new Vector2(screenX, screenY);

        if (Timer_updated.timerIsRunning) 
        { 
            Instantiate(spawnee, pos, transform.rotation); 
        }
        
        else
        {
            stopSpawning = true;
        }

        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
