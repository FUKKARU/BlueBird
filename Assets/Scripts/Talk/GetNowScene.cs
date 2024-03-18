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
        enum E_SceneType { StartTalk, PawnBattleTalk, EnemyBattleTalk, EndTalk };
        E_SceneType sceneType;

        void Start()
        {
            sceneName = SceneManager.GetActiveScene().name;
            int idx = Array.IndexOf(SceneSO.Entity.TalkSceneNames, sceneName);
            //switch
        }

        void Update()
        {

        }
    }
}
