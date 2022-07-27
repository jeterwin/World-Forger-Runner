using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    public GameObject cylinderToSpawn;
    int chance;
    bool canSpawn = true;
    public GameObject tileToSpawn, tileToSpawnVar1, tileToSpawnVar2, tileToSpawnVar3;
    bool goingX = true, goingY = false, goingZ = true;
    public GameObject referenceObject;
    public float timeOffset = 0.6f;
    public float distanceBetweenTiles = 5.0F;
    public float randomValue = 0.8f;
    private Vector3 previousTilePosition;
    private float startTime;
    private Vector3 direction, mainDirection = new Vector3(0, 0, 1), otherDirection = new Vector3(1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        previousTilePosition = referenceObject.transform.position;
        startTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeOffset -= 0.001f * Time.deltaTime;
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
            if (spawnPos.x != previousTilePosition.x && (spawnPos.y == previousTilePosition.y && spawnPos.z == previousTilePosition.z && (goingY == true || goingZ == true)))
            {
                goingX = true;
                goingY = goingZ = false;
                if (Random.Range(1, 100) > 50)
                {
                    tileToSpawn = tileToSpawnVar1;
                }
                else
                {
                    tileToSpawn = tileToSpawnVar2;
                }
            }
            if (spawnPos.y != previousTilePosition.y && (spawnPos.x == previousTilePosition.x && spawnPos.z == previousTilePosition.z && (goingX == true || goingZ == true)))
            {
                goingY = true;
                goingX = goingZ = false;
                if (Random.Range(1, 100) > 50)
                {
                    tileToSpawn = tileToSpawnVar2;
                }
                else
                {
                    tileToSpawn = tileToSpawnVar1;
                }
            }
            if (spawnPos.z != previousTilePosition.z && (spawnPos.x == previousTilePosition.x && spawnPos.y == previousTilePosition.y && (goingX == true || goingY == true)))
            {
                goingZ = true;
                goingX = goingY = false;
                if(Random.Range(1, 100) >= 40)
                {
                    tileToSpawn = tileToSpawnVar3;
                }
                else
                {
                    tileToSpawn = tileToSpawnVar1;
                }
            }
            Instantiate(tileToSpawn, spawnPos, Quaternion.Euler(0, 0, 0));
            chance = Random.Range(0, 100);
            if (chance <= 25 && canSpawn == true)
            {
                Instantiate(cylinderToSpawn, spawnPos + new Vector3(0, 1, 0), Quaternion.Euler(0, 0, 0));
                StartCoroutine(fiveSeconds());
                canSpawn = false;
            }
                previousTilePosition = spawnPos;
        }
    }
    public IEnumerator fiveSeconds()
    {

        yield return new WaitForSeconds(5f);

        canSpawn = true;
    }
}
