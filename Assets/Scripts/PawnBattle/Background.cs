using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Background : MonoBehaviour
    {
        [SerializeField] float speed;

        private void Update()
        {
            Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);

            if (screenPos.x <= -300)
                transform.position = Vector3.zero;
        }

        private void FixedUpdate()
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}