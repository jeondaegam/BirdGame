using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    public float accel = 10f;
    public float gravty = 10f;
    public float currentSppeed;
    private float score;

    [Header("Sfx")]
    public AudioClip upSound;
    public AudioClip downSound;

    // Start is called before the first frame update
    void Start()
    {
        currentSppeed = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 버튼을 누르고 있는 동안 올라가고
        if (Input.GetButton("Jump"))
        {
            currentSppeed -= accel * Time.deltaTime;
        }
        // 떼는 순간 떨어진다
        else
        {
            currentSppeed += gravty * Time.deltaTime;
        }

        PlaySound();
    }

    private void PlaySound()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<AudioSource>().PlayOneShot(upSound);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            GetComponent<AudioSource>().PlayOneShot(downSound);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * currentSppeed * Time.fixedDeltaTime);
    }

    /**
     * 벽과 충돌한 경우 게임오버
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // 플레이어 점수 저장
            score = GameManager.Instance.score;
            PlayerPrefs.SetInt("Score", (int)score);
            PlayerPrefs.Save();

            // 게임 오버
            SceneManager.LoadScene("GameOverScene");
        }
    }

}
