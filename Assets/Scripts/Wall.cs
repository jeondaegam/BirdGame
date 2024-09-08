using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float speed = 5f;

    public float xPositionLimit = -10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    // 새와 부딪혔을 때 물리연산이 필요하므로 FixedUpdate 사용
    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
        RemoveIfOutOfBounds();
    }

    private void RemoveIfOutOfBounds()
    {
        if (transform.position.x < xPositionLimit)
        {
            Destroy(gameObject);
        }
    }
}
