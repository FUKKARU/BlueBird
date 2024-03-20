using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Battle
{
    public class RedImage : MonoBehaviour
    {
        [SerializeField] Image DamageImg;

        void Start()
        {
            DamageImg.color = Color.clear;
        }

        void Update()
        {
            DamageImg.color = Color.Lerp(DamageImg.color, Color.clear, Time.deltaTime);

        }

        public void RedScreen()
        {
            DamageImg.color = new Color(0.7f, 0, 0, 0.7f);
        }
    }

}

