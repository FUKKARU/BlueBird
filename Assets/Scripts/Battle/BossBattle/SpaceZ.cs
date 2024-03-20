using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


namespace Battle
{
    public class SpaceZ : MonoBehaviour
    {
        float speed = 5.0f;


        GameObject blueBird;
        RedImage damageImage;

        Vector3 direction;

        void Start()
        {
            direction = blueBird.transform.position - transform.position;

            Quaternion rot = Quaternion.FromToRotation(Vector3.up, direction);

            transform.rotation = rot * transform.rotation;   
        }


        void Update()
        {
            transform.position += direction.normalized * Time.deltaTime * speed;

            ActiveRegion();
        }

        public void setSpaceZ(GameObject blueBird_IN ,RedImage damageImage_IN)
        {
            blueBird = blueBird_IN;
            damageImage = damageImage_IN;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "BlueBird")
            {
                Camera camera = Camera.main;
                if (camera != null) camera.GetComponent<ScreenShake>().ShakeOn();
                damageImage.RedScreen();
                Destroy(gameObject);
            }
        }

        void ActiveRegion() { if (transform.position.x > 10 || transform.position.y > 10 || transform.position.y < -10) Destroy(gameObject); }

    }
}

