using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Tezla_ShootBehaviour : MonoBehaviour
    {
        GameObject blueBird;

        [SerializeField] GameObject bulletPrefab;


        public void ShootSet(GameObject blueBird_IN)
        {
            blueBird = blueBird_IN;
        }

        public void Shoot ()
        {
            StartCoroutine(Main_Behaiviour());
        }

        void Shot(float angle, float speed)
        {

            Tezla_BulletBehaviour bullet = Instantiate(bulletPrefab, transform.position, transform.rotation).GetComponent<Tezla_BulletBehaviour>();

            bullet.Setting(angle, speed);

        }

        IEnumerator Main_Behaiviour()
        {
            yield return WaveNBlueBirdAimShot(3, 6);
            yield return new WaitForSeconds(3f);
            yield return WaveNShotM(4, 16);
            yield return new WaitForSeconds(3f);
            yield return WaveNShotMCurve(3, 6);
            yield return new WaitForSeconds(3f);
            yield return ShotNCurve(3, 2);
            yield return new WaitForSeconds(3f);
            yield return WaveNBlueBirdAimShot(4, 6);
            yield return new WaitForSeconds(5f);

            yield break;
        }

        ///IE///////////////////////////////////////////////////

        IEnumerator WaveNShotM(int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                shotN(m, 5);

                yield return new WaitForSeconds(0.3f);
            }
        }

        IEnumerator WaveNShotMCurve(int n, int m)
        {
            // 4‰ñ8•ûŒü‚ÉŒ‚‚¿‚½‚¢
            for (int w = 0; w < n; w++)
            {
                yield return new WaitForSeconds(0.3f);

                yield return ShotNCurve(m, 2);
            }
        }

        IEnumerator WaveNBlueBirdAimShot(int n, int m)
        {

            for (int w = 0; w < n; w++)
            {
                yield return new WaitForSeconds(1f);

                BlueBirdAimShot(m, 3);
            }
        }


        IEnumerator ShotNCurve(int count, float speed)
        {
            int bulletCount = count;

            for (int i = 0; i < bulletCount; i++)
            {
                float angle = i * (2 * Mathf.PI / bulletCount); // 2PIF360

                Shot(angle - Mathf.PI / 2f, speed);

                Shot(-angle - Mathf.PI / 2f, speed);

                yield return new WaitForSeconds(0.1f);
            }
        }


        ///////////////////////////////////////////////////////////////////

        void shotN(int count, float speed)
        {
            int bulletCount = count;

            for (int i = 0; i < bulletCount; i++)
            {
                float angle = i * (2 * Mathf.PI / bulletCount);

                Shot(angle, speed);
            }
        }


        void BlueBirdAimShot(int count, float speed)
        {

            if (blueBird != null)
            {

                Vector3 diffPosition = blueBird.transform.position - transform.position;

                float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);

                int bulletCount = count;

                for (int i = 0; i < bulletCount; i++)
                {
                    float angle = (i - bulletCount / 2f) * ((Mathf.PI / 2f) / bulletCount);

                    Shot(angleP + angle, speed);
                }
            }
        }

    }
}

