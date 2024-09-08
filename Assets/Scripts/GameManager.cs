using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public GameObject wallPrefab;

    public float spawnTerm = 4f;

    public float spawnTimer;

    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0;
        //StartCoroutine("SpawnWalls");
    }

    //IEnumerator SpawnWalls()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(4);
    //        wall = Instantiate(wallPrefab, new Vector3(10, 0, 0), Quaternion.identity);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnTerm)
        {
            wall = Instantiate(wallPrefab);
            //spawnTimer = 0;
            wall.transform.position = new Vector2(10, Random.Range(-2f, 2f));
            spawnTimer -= spawnTerm;
        }
    }

}
