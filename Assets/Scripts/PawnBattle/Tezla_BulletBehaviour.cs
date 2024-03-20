using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Tezla_BulletBehaviour : MonoBehaviour
    {
        float dx;
        float dy;

        public void Setting(float angle, float speed)
        {
            dx = Mathf.Cos(angle) * speed;
            dy = Mathf.Sin(angle) * speed;
        }

        void Update()
        {
            ActiveRegion();

            transform.position += new Vector3(dx, dy, 0) * Time.deltaTime;

            if (transform.position.x < -9 || transform.position.x > 9 ||
                transform.position.y < -6 || transform.position.y > 6)
            {
                Destroy(gameObject);
            }

        }

        void ActiveRegion() { if (transform.position.x > 10 || transform.position.y > 10 || transform.position.y < -10) Destroy(gameObject); }
    }
}

