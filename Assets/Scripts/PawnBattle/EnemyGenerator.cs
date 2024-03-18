using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class EnemyGenerator : MonoBehaviour
    {
        [SerializeField] Enemy enemyPrefab;
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
            Enemy enemy = Instantiate(enemyPrefab, generatePoints[index].position, Quaternion.identity);
            isExist[index] = true;
            enemy.Set(this, index, destinationPoints[index]);
        }

        public void PointToBlank(int index)
        {
            isExist[index] = false;
        }
    }
}
