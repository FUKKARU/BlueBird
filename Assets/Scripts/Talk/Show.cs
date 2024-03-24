using General;
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
    public class Show : MonoBehaviour
    {
        [SerializeField] AudioSource bgmAs;
        [SerializeField] AudioSource seAs;
        [SerializeField] Image textIcon;
        [SerializeField] Image[] speakerImages;
        [SerializeField] Image fadeOutImage;
        Image targetImage; // �\������ׂ������G
        TextMeshProUGUI textComp;
        TextTable textTable;
        string sceneName;
        string gottenText;
        string[] text;
        int nowRow = 1; // ���s�ڂ�\�����邩
        int rowLen; // �S���ŉ��s���邩
        bool isClicked = false; // �N���b�N���ꂽ���ǂ���
        bool isOnSkipInterval = false; // �X�L�b�v�̓��͂̃C���^�[�o�������ǂ���
        bool isClickable = true; // �v���C���[�̓��͂��󂯕t���邩
        bool isSkipable = false; // �e�L�X�g���X�L�b�v�\���ǂ���
        bool isBeganSceneChange = false; // �V�[���J�ڂ��J�n�������ǂ���
        Coroutine showCharsCor;
        Coroutine countSkipTimeCor;

        void Start()
        {
            textComp = GetComponent<TextMeshProUGUI>();

            sceneName = SceneManager.GetActiveScene().name;
            textTable = TalkSO.Entity.GetTextTable(sceneName);
            gottenText = textTable.Text;
            text = gottenText.Split("\n", StringSplitOptions.None);
            rowLen = text.Length;

            isClickable = false;
            textIcon.enabled = false;

            foreach (Image img in speakerImages)
            {
                img.enabled = false;
            }
            targetImage = speakerImages[0]; // �K����
            fadeOutImage.color = new Color(0, 0, 0, 0);

            bgmAs.playOnAwake = false;
            bgmAs.loop = true;
            bgmAs.clip = GeneralSO.Entity.BGM.TalkBGM.Clip;
            bgmAs.volume = GeneralSO.Entity.BGM.TalkBGM.DefaultSoundVolume;
            bgmAs.outputAudioMixerGroup = GeneralSO.Entity.BGM.Group;

            seAs.playOnAwake = false;
            seAs.loop = true;
            seAs.clip = GeneralSO.Entity.SE.OnTalkCaptionSE.Clip;
            seAs.volume = GeneralSO.Entity.SE.OnTalkCaptionSE.DefaultSoundVolume;
            seAs.outputAudioMixerGroup = GeneralSO.Entity.SE.Group;

            ShowText(1);
            bgmAs.Play();
        }

        void Update()
        {
            if (isClickable && !isOnSkipInterval && isClicked)
            {
                isClickable = false;
                isOnSkipInterval = true;
                isClicked = false;
                StartCoroutine(CountSkipInterval());

                textIcon.enabled = false;

                if (nowRow <= rowLen)
                {
                    ShowText(nowRow);
                }
                else
                {
                    if (!isBeganSceneChange)
                    {
                        isBeganSceneChange = true;

                        StartCoroutine(SceneChange());
                    }

                    isClickable = true;
                }
            }

            if (isSkipable && !isOnSkipInterval && isClicked)
            {
                isSkipable = false;
                isOnSkipInterval = true;
                isClicked = false;
                StartCoroutine(CountSkipInterval());

                if (nowRow <= rowLen)
                {
                    if (showCharsCor != null) StopCoroutine(showCharsCor);
                    showCharsCor = null;

                    // textIcon.enabled = false;
                    seAs.Stop();

                    textComp.text = RmTag(text[nowRow - 1]);
                    nowRow++;
                }

                isClickable = true;
            }
        }

        public void OnClick()
        {
            isClicked = true;
        }

        void ShowText(int rowIdx)
        {
            char[] chars = text[rowIdx - 1].ToCharArray(); // 1����������
            showCharsCor = StartCoroutine(ShowChars(chars));
            DisplaySpeaker(text[rowIdx - 1]);
        }

        IEnumerator ShowChars(char[] chars)
        {
            countSkipTimeCor = StartCoroutine(CountSkipTime(TalkSO.Entity.SkipTime));

            seAs.Play();

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

                yield return new WaitForSeconds(TalkSO.Entity.CharsShowInterval);
            }

            isSkipable = false;

            if (countSkipTimeCor != null) StopCoroutine(countSkipTimeCor);
            countSkipTimeCor = null;

            textIcon.enabled = true;
            seAs.Stop();

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
            yield return new WaitForSeconds(TalkSO.Entity.SkipInterval);
            isOnSkipInterval = false;
        }

        string RmTag(string text)
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

        void DisplaySpeaker(string s)
        {
            targetImage.enabled = false;

            if (Regex.IsMatch(s, "{None}"))
                return;

            if (Regex.IsMatch(s, "{�E�[�����E�}�X�N������}"))
                targetImage = speakerImages[0];

            else if (Regex.IsMatch(s, "{�H�H�H}"))
                targetImage = speakerImages[1];

            else if (Regex.IsMatch(s, "{Twit}"))
                targetImage = speakerImages[2];

            else if (Regex.IsMatch(s, "{�`���`��}"))
                targetImage = speakerImages[3];

            else if (Regex.IsMatch(s, "{�~�`��}"))
                targetImage = speakerImages[4];

            else if (Regex.IsMatch(s, "{�X�Y����}"))
                targetImage = speakerImages[5];

            else if (Regex.IsMatch(s, "{�X�Y����After}"))
                targetImage = speakerImages[6];

            else if (Regex.IsMatch(s, "{TEZLA}"))
                targetImage = speakerImages[7];

            else if (Regex.IsMatch(s, "{�傫�ȃg�J�Q}"))
                targetImage = speakerImages[8];

            if (Regex.IsMatch(s, "{Unknown}"))
                targetImage.color = Color.black;
            else
                targetImage.color = Color.white;

            targetImage.enabled = true;
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
                    SceneManager.LoadScene(textTable.ToSceneName);

                    yield break;
                }
            }
        }
    }
}
