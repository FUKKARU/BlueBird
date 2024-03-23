using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class YellowImage : MonoBehaviour
    {
        [SerializeField] Image lightningImg;

        void Start()
        {
            lightningImg.color = Color.clear;
        }

        void Update()
        {
            lightningImg.color = Color.Lerp(lightningImg.color, Color.clear, Time.deltaTime);

        }

        public void YellowScreen()
        {
            lightningImg.color = new Color(0.7f, 0.7f, 0, 0.7f);
        }
    }
}

