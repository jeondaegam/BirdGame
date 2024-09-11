using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    // 요 위에서 값을 할당하는 경우에는 인스펙터 설정값이 우선시됨 
    public float speed = 2f;
    public float xPositionLimit = -10;

    [Header("Position Setting")]
    public float startPositionY = 5f;
    public float endPositionY = 4f;

    public bool isGoingUp = false;

    private bool turnSwitch = true;


    // Start is called before the first frame update
    void Start()
    {
        // Start나 Awake에서 값을 초기화 하는 경우 인스펙터의 값도 같이 초기화된다 
        // 인스펙터에서 설정한 값을 사용하려는 경우 Start문 혹은 Awake문을 통해 초기화 금지 X 
        // isGoingUp = false;
    }

    // 새와 부딪혔을 때 물리연산이 필요하므로 FixedUpdate 사용
    private void FixedUpdate()
    {
        // 땅에 배치되어 위로 올라오는경우
        if (isGoingUp)
        {   // from down to up 
            if (transform.position.y > -endPositionY) 
            {
                turnSwitch = false;
            }
            else if (transform.position.y < -startPositionY)
            {
                turnSwitch = true;
            }

            if (turnSwitch)
            {
                transform.Translate(Vector2.up * speed * Time.fixedDeltaTime);
            }
            else
            {
                transform.Translate(Vector2.down * speed * Time.fixedDeltaTime);
            }

        }
        else // 하늘에 배치되어 아래로 내려가는 경우 
        {
            // from up to down 
            if (transform.position.y < endPositionY)
            {
                turnSwitch = false;
            }
            else if (transform.position.y > startPositionY)
            {
                turnSwitch = true;
            }

            if (turnSwitch)
            {
                transform.Translate(Vector2.down * speed * Time.fixedDeltaTime);
            }
            else
            {
                transform.Translate(Vector2.up * speed * Time.fixedDeltaTime);
            }
        }

    }

}
