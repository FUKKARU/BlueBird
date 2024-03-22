using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Battle
{
    public class Background : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] Transform start;
        [SerializeField] Transform end;

        private void Update()
        {
            if (Vector3.Distance(transform.position, end.position) < 0.1f)
                transform.position = start.position;
        }

        private void FixedUpdate()
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}