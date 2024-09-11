using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public GameObject wallPrefab;
    private GameObject wall;

    public GameObject[] fencePrefabs;

    public float spawnTerm = 4f;
    public float spawnTimer;

    public TextMeshProUGUI scoreLabel;
    public float score { get; private set; }


    private void Awake()
    {
        // 인스턴스화 되는 순간 자신을 넣는다 
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0;
        score = 0;
        //StartCoroutine("SpawnWalls");
    }

    void Update()
    {
        UpdateScore();
        //SpawnWall();

        SpawnRandomFence();
    }

    private void SpawnRandomFence()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnTerm)
        {
            GameObject randomFence = Instantiate(fencePrefabs[Random.Range(0, fencePrefabs.Length)]);
            if (randomFence.name.StartsWith("Wall"))
            {
                randomFence.transform.position = new Vector2(10, Random.Range(-2f, 2f));
            }
            else
            {
                // y값은 오브젝트에 설정된 y값 고정
                randomFence.transform.position = new Vector3(10, randomFence.transform.position.y);
            }
            spawnTimer -= spawnTerm;
        }
    }

    //IEnumerator SpawnWalls()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(4);
    //        wall = Instantiate(wallPrefab, new Vector3(10, 0, 0), Quaternion.identity);
    //    }
    //}


    /**
     * 벽을 스폰한다
     */
    private void SpawnWall()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnTerm)
        {
            wall = Instantiate(wallPrefab);
            wall.transform.position = new Vector2(10, Random.Range(-2f, 2f));
            //spawnTimer = 0;
            spawnTimer -= spawnTerm;
        }
    }

    /**
     * 실시간으로 점수를 계산한다
     * 점수 = 플레이 시간
     */
    private void UpdateScore()
    {
        score += Time.deltaTime;
        scoreLabel.text = ((int)score).ToString();
    }
}
