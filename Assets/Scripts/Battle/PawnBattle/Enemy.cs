using battle;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Battle
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] float speed;
        GameObject blueBird;
        EnemyGenerator generator;
        int index = -1;
        Transform destination;
        bool isSet;
        bool isReach;

        private void OnDestroy()
        {
            generator.PointToBlank(index);
        }

        [SerializeField, Range(0, 1)] float value;

        private void Update()
        {
            PropellerMov();
            ActiveRegion();
            
            if (!isSet)
                return;

            if (Vector3.Distance(transform.position, blueBird.transform.position) < 5.0f)
            {
                Quaternion rot = Quaternion.LookRotation(blueBird.transform.position - transform.position,transform.up);
                //Quaternion rot = Quaternion.FromToRotation(-transform.up, blueBird.transform.position);

                transform.rotation = Quaternion.Slerp(transform.rotation, rot, value);
            }

            if (Vector3.Distance(transform.position, blueBird.transform.position) < 3.5f)
                isReach = true;
        }

        private void FixedUpdate()
        {
            if (isReach) 
                transform.position += 0.005f * new Vector3(Mathf.Cos(Time.time), Mathf.Sin(Time.time));
            else
                transform.position = Vector3.MoveTowards(transform.position, blueBird.transform.position, speed * Time.deltaTime);
        }

        public void Set(EnemyGenerator eg, int num, Transform point,GameObject blueBird_IN)
        {
            generator = eg;
            index = num;
            destination = point;
            isSet = true;
            blueBird = blueBird_IN;
        }

        void PropellerMov()
        {
            //ƒvƒƒyƒ‰‚Ì‚æ‚¤‚È“®‚«
            float anglePerSec = 800 * Time.deltaTime;//ˆê•b‚É‚W‚O‚O“x‰ñ“]
            transform.rotation = Quaternion.AngleAxis(anglePerSec, transform.up) * transform.rotation;
        }

        void ActiveRegion() { if (transform.position.x > 10 || transform.position.y > 10 || transform.position.y < -10) Destroy(gameObject); }
    }
}