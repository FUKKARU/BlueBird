using battle;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Battle
{
    public class Tezla : MonoBehaviour
    {
        [SerializeField] float speed;
        GameObject blueBird;
        TezlaGenerator generator;
        int index = -1;
        Transform destination;
        bool isSet;
        bool isReach;
        bool shootEnabled = false;
        Tezla_ShootBehaviour tezlaSB;

        public bool chase = true;
        private void OnDestroy()
        {
            if(chase)
            {
                generator.PointToBlank(index);
            }
            
            
        }

        void Start()
        {
            tezlaSB = GetComponent<Tezla_ShootBehaviour>();
        }

        private void Update()
        {
            PropellerMov();
            ActiveRegion();
            //LimitMovement_T();

            if (!isSet)
                return;


            if (Vector3.Distance(transform.position, blueBird.transform.position) < 3.5f)
            {
                isReach = true;
                if (!shootEnabled)
                {
                    tezlaSB.Shoot();
                    shootEnabled = true;
                }

            }
        }
        private void FixedUpdate()
        {
            if (chase)
            {
                if (isReach)
                    transform.position += 0.005f * new Vector3(Mathf.Cos(Time.time), Mathf.Sin(Time.time));
                else
                    transform.position = Vector3.MoveTowards(transform.position, blueBird.transform.position, speed * Time.deltaTime);
            }

        }

        public void Set(TezlaGenerator eg, int num, Transform point,GameObject blueBird_IN)
        {
            generator = eg;
            index = num;
            destination = point;
            isSet = true;
            blueBird = blueBird_IN;
        }

        void PropellerMov()
        {
            //プロペラのような動き
            float anglePerSec = 800 * Time.deltaTime;//一秒に８００度回転
            transform.rotation = Quaternion.AngleAxis(anglePerSec, transform.up) * transform.rotation;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "BlueBird")
            {
                Camera camera = Camera.main;
                if (camera != null) camera.GetComponent<ScreenShake>().ShakeOn();

                Destroy(gameObject);
            }
        }

        private void LimitMovement_T()
        {
            Vector3 cPos = this.transform.position;
            cPos.y = Mathf.Clamp(cPos.y, -4.5f, 4.5f);

            this.transform.position = cPos;
        }

        void ActiveRegion() { if (transform.position.x > 10 || transform.position.y > 10 || transform.position.y < -10) Destroy(gameObject); }
    }
}