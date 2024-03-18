using battle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class EnemyGenerator : MonoBehaviour
    {
        [SerializeField] GameObject blueBird;

        [SerializeField] GameObject enemyPrefab;
        [SerializeField] Transform[] generatePoints;
        [SerializeField] Transform[] destinationPoints;
        bool[] isExist;

        private void Start()
        {
            isExist = new bool[generatePoints.Length];

            for (int i = 0; i < generatePoints.Length; i++)
                Generate(i);
        }

        private void Update()
        {
            for (int i = 0; i < isExist.Length; i++)
            {
                if (!isExist[i])
                    Generate(i);
            }
        }

        private void Generate(int index)
        {
            GameObject tezla = Instantiate(enemyPrefab, generatePoints[index].position, Quaternion.identity);
            Enemy enemy = tezla.GetComponent<Enemy>();
            isExist[index] = true;
            enemy.Set(this, index, destinationPoints[index]);
            Tezla_ShootBehaviour tezla_ShootBehaviour = tezla.GetComponent<Tezla_ShootBehaviour>();
            tezla_ShootBehaviour.blueBird = blueBird;
        }

        public void PointToBlank(int index)
        {
            isExist[index] = false;
        }
    }
}
