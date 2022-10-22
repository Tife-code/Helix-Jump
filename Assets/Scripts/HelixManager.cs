using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public float ySpawnPos = 0;
    private int ringDistance = 5;
    public int numberOfRings;

    // Start is called before the first frame update
    void Start()
    {
        numberOfRings = GameManager.currentLevelIndex + 5;

        for (int i = 0; i < numberOfRings; i++)
        {
            if(i == 0)
            {
                SpawnRings(0);

            }
            else
            {
                SpawnRings(Random.Range(1, helixRings.Length - 1));

            }
        }
        SpawnRings(helixRings.Length - 1);
    }

    public void SpawnRings(int ringIndex)
    {
        GameObject go = Instantiate(helixRings[ringIndex], transform.up * ySpawnPos, Quaternion.identity);
        go.transform.parent = transform;
        ySpawnPos -= ringDistance;
    }
}
