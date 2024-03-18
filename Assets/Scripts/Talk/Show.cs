using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Talk
{
    public class Show : MonoBehaviour
    {
        TextMeshProUGUI textComp;
        AudioSource audioSource;
        string sceneName;
        string gottenText;
        string[] text;
        int nowRow = 1; // ���s�ڂ�\�����邩
        int rowLen; // �S���ŉ��s���邩
        bool isClickable = true; // �v���C���[�̓��͂��󂯕t���邩
        bool isSkipable = false; // �e�L�X�g���X�L�b�v�\���ǂ���
        Coroutine showCharsCor;
        Coroutine countSkipTimeCor;

        void Start()
        {
            textComp = GetComponent<TextMeshProUGUI>();
            audioSource = GetComponent<AudioSource>();

            // �e�L�X�g�̎擾
            GetText_Split_CalcRowNum();
        }

        void Update()
        {
            if (isClickable && Input.GetKeyDown(KeyCode.Space))
            {
                isClickable=false;

                if (nowRow <= rowLen)
                {
                    ShowText(nowRow);
                }
                else
                {
                    Debug.Log("�I��肾��");
                    isClickable = true;
                }
            }

            if (isSkipable && Input.GetKeyDown(KeyCode.Return))
            {
                isSkipable = false;

                if (nowRow <= rowLen)
                {
                    if (showCharsCor != null) StopCoroutine(showCharsCor);
                    showCharsCor = null;

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
            char[] chars = text[rowIdx - 1].ToCharArray(); // 1����������
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

            audioSource.Stop();

            nowRow++;

            isClickable = true;
        }
        IEnumerator CountSkipTime(float time)
        {
            yield return new WaitForSeconds(time);
            isSkipable = true;
        }
    }
}
