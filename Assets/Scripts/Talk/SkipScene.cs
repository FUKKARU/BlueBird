using General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Talk
{
    public class SkipScene : MonoBehaviour
    {
        [SerializeField] Show showInstance;
        [SerializeField] Image fadeOutImage;
        bool isSkipable = true;

        public void OnClick()
        {
            if (isSkipable)
            {
                showInstance.enabled = false;
                StartCoroutine(SceneChange());
            }
        }

        IEnumerator SceneChange()
        {
            float time = 0;

            while (true)
            {
                time += Time.deltaTime;

                if (time < GeneralSO.Entity.FadeOutDuration)
                {
                    float a = time / GeneralSO.Entity.FadeOutDuration;
                    fadeOutImage.color = new Color(0, 0, 0, a);

                    yield return null;
                }
                else
                {
                    fadeOutImage.color = new Color(0, 0, 0, 1);

                    string sceneName = SceneManager.GetActiveScene().name;
                    TextTable textTable = TalkSO.Entity.GetTextTable(sceneName);
                    SceneManager.LoadScene(textTable.ToSceneName);

                    yield break;
                }
            }
        }
    }
}

