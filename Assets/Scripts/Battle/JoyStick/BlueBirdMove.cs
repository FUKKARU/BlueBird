using Battle;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace battle
{
    public class BlueBirdMove : MonoBehaviour
    {

        //ジョイスティックを入れる
        [SerializeField] FixedJoystick joyStick;

        //スピード
        [SerializeField] float speed;

        Enemy [] enemies;

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

