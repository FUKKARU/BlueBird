using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickInput : MonoBehaviour
{
    //�W���C�X�e�B�b�N������
    [SerializeField] FixedJoystick joyStick;

    //�X�s�[�h
    [SerializeField] float speed;

    //������������
    float inputH;

    //������������
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
