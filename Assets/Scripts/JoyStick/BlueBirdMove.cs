using Battle;
using System;
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

        Enemy [] enemies;

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
            cPos.x = Mathf.Clamp(cPos.x, -8.4f, 8.4f);
            cPos.y = Mathf.Clamp(cPos.y, -4.5f, 4.5f);

            this.transform.position = cPos;
        }

        public void Tweet()
        {
            enemies = FindObjectsOfType<Enemy>();
            int rand = UnityEngine.Random.Range(1,enemies.Length);
            Destroy(enemies[rand].gameObject);
        }
    }
}

