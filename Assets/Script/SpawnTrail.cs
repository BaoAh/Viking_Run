using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrail : MonoBehaviour
{
    public GameObject tileToSpawn;
    public GameObject referenceObject;
    public float timeOffset = 0.4f;
    public float distanceBetweenTiles = 7.0F;
    public float randomValue = 0.6f;
    private Vector3 previousTilePosition;
    private float startTime;
    private Vector3 direction, mainDirection = new Vector3(0, 0, 1), otherDirection = new Vector3(1, 0, 0);
    private bool lastDestroy = false;

    // Start is called before the first frame update
    void Start()
    {
        previousTilePosition = referenceObject.transform.position;
        startTime = Time.time;
        TheFirstFloor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > timeOffset)
        {
            if (Random.value < randomValue)
                direction = mainDirection;
            else
            {
                Vector3 temp = direction;
                direction = otherDirection;
                mainDirection = direction;
                otherDirection = temp;
            }
            Vector3 spawnPos = previousTilePosition + distanceBetweenTiles * direction;
            startTime = Time.time;
            GameObject floor = Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
            previousTilePosition = spawnPos;

            //???ͧ|?}
            if ((lastDestroy == false) && (Random.value < 0.05))
            {
                Destroy(floor);
                lastDestroy = true;
            }
            else if (Random.value >= 0.05)
            {
                lastDestroy = false;
            }
        }

        
    }
    private void TheFirstFloor()
    {
        direction = mainDirection;
        Vector3 spawnPos = previousTilePosition + distanceBetweenTiles * direction;
        startTime = Time.time;
        GameObject floor = Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
        previousTilePosition = spawnPos;
    }
}
