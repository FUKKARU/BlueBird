using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickInput : MonoBehaviour
{
    //ジョイスティックを入れる
    [SerializeField] FixedJoystick joyStick;

    //スピード
    [SerializeField] float speed;

    //水平方向入力
    float inputH;

    //垂直方向入力
    float inputV;

    void Start()
    {
        
    }

    void Update()
    {
        InputMovement();
    }

    private void InputMovement()
    {
        inputH = joyStick.Horizontal * speed * Time.deltaTime;
        inputV = joyStick.Vertical * speed * Time.deltaTime;

        transform.Translate(inputH,inputV,0);
    }
}
