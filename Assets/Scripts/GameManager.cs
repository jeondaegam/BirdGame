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
    public GameObject wall;

    public float spawnTerm = 4f;
    public float spawnTimer;

    public TextMeshProUGUI scoreLabel;
    public float score { get; private set; }


    private void Awake()
    {
        // 인스턴스화 되는 순간 자신을 넣는다 . 
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
        SpawnWall();
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

    /**
     * 벽을 스폰한다
     */
    private void SpawnWall()
    {
        if (spawnTimer >= spawnTerm)
        {
            wall = Instantiate(wallPrefab);
            //spawnTimer = 0;
            wall.transform.position = new Vector2(10, Random.Range(-2f, 2f));
            spawnTimer -= spawnTerm;
        }
    }

    /**
     * 실시간으로 점수를 계산한다
     * 점수 = 플레이 시간
     */
    private void UpdateScore()
    {
        spawnTimer += Time.deltaTime;
        score += Time.deltaTime;
        scoreLabel.text = ((int)score).ToString();
    }
}
