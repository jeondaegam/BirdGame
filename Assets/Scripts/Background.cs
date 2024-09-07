using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 5f;
    public float size = 19.2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 좌측으로 이미지를 이동 
        //transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <-size)
        {
            // 이미지의 x position을 현재 위치에서 (size * 2)를 더한 지점에 배치한다.
            transform.Translate(new Vector3(size * 2, 0, 0));
        }
    }
}
