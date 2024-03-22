using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Battle
{
    public class RedImage : MonoBehaviour
    {
        [SerializeField] Image damageImg;

        void Start()
        {
            damageImg.color = Color.clear;
        }

        void Update()
        {
            damageImg.color = Color.Lerp(damageImg.color, Color.clear, Time.deltaTime);

        }

        public void RedScreen()
        {
            damageImg.color = new Color(0.7f, 0, 0, 0.7f);
        }
    }

}

