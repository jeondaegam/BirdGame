using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 3f;
    public float size = 19.2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 좌측으로 배경사진을 이동 
        transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);

        if (transform.position.x <-size)
        {
            // 배경사진의 위치를 변경한다 . 두 번째 이미지 다음 위치로  
            transform.Translate(new Vector3(size * 2, 0, 0));
        }
    }
}
