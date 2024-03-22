using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Talk
{
    public class Show : MonoBehaviour
    {
        [SerializeField] Image textIcon;
        TextMeshProUGUI textComp;
        AudioSource audioSource;
        string sceneName;
        string gottenText;
        string[] text;
        int nowRow = 1; // 何行目を表示するか
        int rowLen; // 全部で何行あるか
        bool isOnSkipInterval = false; // スキップの入力のインターバル中かどうか
        bool isClickable = true; // プレイヤーの入力を受け付けるか
        bool isSkipable = false; // テキストをスキップ可能かどうか
        Coroutine showCharsCor;
        Coroutine countSkipTimeCor;

        void Start()
        {
            textComp = GetComponent<TextMeshProUGUI>();
            audioSource = GetComponent<AudioSource>();

            // テキストの取得
            GetText_Split_CalcRowNum();

            isClickable = false;
            textIcon.enabled = false;
            ShowText(1);
        }

        void Update()
        {
            if (isClickable && !isOnSkipInterval && Input.GetMouseButtonDown(0))
            {
                isClickable = false;
                isOnSkipInterval = true;
                StartCoroutine(CountSkipInterval());

                textIcon.enabled = false;

                if (nowRow <= rowLen)
                {
                    ShowText(nowRow);
                }
                else
                {
                    Debug.Log("終わりだよ");
                    isClickable = true;
                }
            }

            if (isSkipable && !isOnSkipInterval && Input.GetMouseButtonDown(0))
            {
                isSkipable = false;
                isOnSkipInterval = true;
                StartCoroutine(CountSkipInterval());

                if (nowRow <= rowLen)
                {
                    if (showCharsCor != null) StopCoroutine(showCharsCor);
                    showCharsCor = null;

                    // textIcon.enabled = false;
                    audioSource.Stop();

                    textComp.text = text[nowRow - 1];
                    nowRow++;
                }

                isClickable = true;
            }
        }

        void GetText_Split_CalcRowNum()
        {
            sceneName = SceneManager.GetActiveScene().name;
            gottenText = SceneSO.Entity.GetText(sceneName);
            text = gottenText.Split("\n", StringSplitOptions.None);
            rowLen = text.Length;
        }

        void ShowText(int rowIdx)
        {
            char[] chars = text[rowIdx - 1].ToCharArray(); // 1文字ずつ分割
            showCharsCor = StartCoroutine(ShowChars(chars));
        }

        IEnumerator ShowChars(char[] chars)
        {
            countSkipTimeCor = StartCoroutine(CountSkipTime(SceneSO.Entity.SkipTime));

            audioSource.clip = SceneSO.Entity.CaptionSE;
            audioSource.Play();

            string showText = "";

            foreach (char c in chars)
            {
                showText += c;
                textComp.text = showText;

                yield return new WaitForSeconds(SceneSO.Entity.CharsShowInterval);
            }

            isSkipable = false;

            if (countSkipTimeCor != null) StopCoroutine(countSkipTimeCor);
            countSkipTimeCor = null;

            textIcon.enabled = true;
            audioSource.Stop();

            nowRow++;

            isClickable = true;
        }

        IEnumerator CountSkipTime(float time)
        {
            yield return new WaitForSeconds(time);
            isSkipable = true;

            textIcon.enabled = true;
        }

        IEnumerator CountSkipInterval()
        {
            yield return new WaitForSeconds(SceneSO.Entity.SkipInterval);
            isOnSkipInterval = false;
        }
    }
}
