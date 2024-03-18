using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Battle
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] float speed;
        EnemyGenerator generator;
        int index = -1;
        Transform destination;
        bool isSet;
        bool isReach;

        private void OnDestroy()
        {
            generator.PointToBlank(index);
        }

        private void Update()
        {
            if (!isSet)
                return;

            if (Vector3.Distance(transform.position, destination.position) < 0.1f)
                isReach = true;
        }

        private void FixedUpdate()
        {
            if (isReach) 
                transform.position += 0.005f * new Vector3(Mathf.Cos(Time.time), Mathf.Sin(Time.time));
            else
                transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
        }

        public void Set(EnemyGenerator eg, int num, Transform point)
        {
            generator = eg;
            index = num;
            destination = point;
            isSet = true;
        }
    }
}