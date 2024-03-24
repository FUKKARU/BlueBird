using General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FirstClick
{
    public class ToTitle : MonoBehaviour
    {
        [SerializeField] Image FadeOutImage;
        bool isBeganSceneChange = false; // シーン遷移を開始したかどうか

        public void OnClick()
        {
            if (!isBeganSceneChange)
            {
                isBeganSceneChange = true;

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
                    FadeOutImage.color = new Color(0, 0, 0, a);

                    yield return null;
                }
                else
                {
                    FadeOutImage.color = new Color(0, 0, 0, 1);
                    SceneManager.LoadScene("Title");

                    yield break;
                }
            }
        }
    }
}
