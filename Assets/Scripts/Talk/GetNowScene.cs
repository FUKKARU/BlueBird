using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Talk
{
    public class GetNowScene : MonoBehaviour
    {
        string sceneName;
        string text;

        void Start()
        {
            sceneName = SceneManager.GetActiveScene().name;
            //text = SceneSO.Entity.Texts.IndexOf(sceneName);
        }

        void Update()
        {

        }
    }
}
