using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace battle
{
    public class BlueBirdMove : MonoBehaviour
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
            LimitMovement();
        }

        private void InputMovement()
        {
            inputH = joyStick.Horizontal * speed * Time.deltaTime;
            inputV = joyStick.Vertical * speed * Time.deltaTime;

            transform.Translate(inputH, inputV, 0);
        }

        private void LimitMovement()
        {
            Vector3 cPos = this.transform.position;
            cPos.x = Mathf.Clamp(cPos.x, -2.1f, 2.1f);
            cPos.y = Mathf.Clamp(cPos.y, -5.1f, 5.1f);

            this.transform.position = cPos;
        }
    }
}

