using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float accel = 10f;
    public float gravty = 10f;

    public float currentSppeed;
    // Start is called before the first frame update
    void Start()
    {
        currentSppeed = 0;
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
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * currentSppeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Game Over - !");
    }
}
