using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {
    public GameObject Standard_Platform;
    public GameObject Danger_Platform;
    public GameObject Exploision_Platform;

    public float spawnTimer = 2f; //Set time for spawing
    public float currentTimeSpawner; // Set time current obj spawner

    private int PlatformSpawnCount; //count how many platforms in the scene

    public float min_X = -1.5f , max_X = 1.5f ; //Set border for the platform




	// Use this for initialization
	void Start () {
        currentTimeSpawner = spawnTimer;


    }
	
	// Update is called once per frame
	void Update () {
        SpawnPlatforms();
	}

    void SpawnPlatforms()
    {
        currentTimeSpawner += Time.deltaTime;
        if(currentTimeSpawner >= spawnTimer)
        {
            PlatformSpawnCount++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_X);

            GameObject newPlatform = null;
            if (PlatformSpawnCount < 2)
            {
                newPlatform = Instantiate(Standard_Platform, temp, Quaternion.identity);

            }
            else if (PlatformSpawnCount == 2)
            {

                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(Standard_Platform, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(Danger_Platform, temp, Quaternion.identity);
                }

            }


            else if (PlatformSpawnCount == 3)
            {

                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(Standard_Platform, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(Exploision_Platform, temp, Quaternion.identity);
                }
                PlatformSpawnCount = 0; //reset the platform counting

            }


                if (newPlatform)
            newPlatform.transform.parent = transform; // make the clone platform  become parent of this object
            currentTimeSpawner = 0f; // reset the current time spawner
        }
    }




}
