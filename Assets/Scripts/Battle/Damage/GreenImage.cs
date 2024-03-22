using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Battle
{
    public class GreenImage : MonoBehaviour
    {
        [SerializeField] Image recoverImg;

        void Start()
        {
            recoverImg.color = Color.clear;
        }

        void Update()
        {
            recoverImg.color = Color.Lerp(recoverImg.color, Color.clear, Time.deltaTime);
        }

        public void GreenScreen()
        {
            recoverImg.color = new Color(0, 0.7f, 0, 0.7f);
        }
    }

}

