using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Talk
{
    public class ShowMatsumoto : MonoBehaviour
    {
        [SerializeField] Image textIcon;
        [SerializeField] Image speakerImg;
        [SerializeField] Sprite[] sprites;
        TextMeshProUGUI textComp;
        AudioSource audioSource;
        string sceneName;
        string gottenText;
        string[] text;
        int nowRow = 1; // ���s�ڂ�\�����邩
        int rowLen; // �S���ŉ��s���邩
        bool isOnSkipInterval = false; // �X�L�b�v�̓��͂̃C���^�[�o�������ǂ���
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

            isClickable = false;
            textIcon.enabled = false;
            speakerImg.gameObject.SetActive(false);
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
                    DisplaySpeaker(text[nowRow - 1]);
                    ShowText(nowRow);
                }
                else
                {
                    Debug.Log("�I��肾��");
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

                    textComp.text = RmTag(text[nowRow - 1]);
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
            bool isContinue = false;

            foreach (char c in chars)
            {
                if (c == '{' || c == '}')
                {
                    isContinue = !isContinue;
                    continue;
                }

                if (isContinue)
                    continue;

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

        private string RmTag(string text)
        {
            string removed = string.Empty;
            bool isContinue = false;

            foreach (char c in text)
            {
                if (c == '{' || c == '}')
                {
                    isContinue = !isContinue;
                    continue;
                }

                if (isContinue)
                    continue;

                removed += c;
            }

            return removed;
        }

        private void DisplaySpeaker(string s)
        {
            speakerImg.gameObject.SetActive(true);

            if (Regex.IsMatch(s, "{�E�[�����E�}�X�N������}"))
                speakerImg.sprite = sprites[0];

            else if (Regex.IsMatch(s, "{�H�H�H}"))
                speakerImg.sprite = sprites[1];

            else if (Regex.IsMatch(s, "{Twit}"))
                speakerImg.sprite = sprites[2];

            else if (Regex.IsMatch(s, "{�`���`��}"))
                speakerImg.sprite = sprites[3];

            else if (Regex.IsMatch(s, "{�~�`��}"))
                speakerImg.sprite = sprites[4];

            else if (Regex.IsMatch(s, "{TEZLA}"))
                speakerImg.sprite = sprites[5];

            else if (Regex.IsMatch(s, "{None}"))
                speakerImg.gameObject.SetActive(false);

            else
                speakerImg.gameObject.SetActive(false);
        }
    }
}
