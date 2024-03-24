using System;
using System.Collections.Generic;
using UnityEngine;

namespace Talk
{
    [CreateAssetMenu(menuName = "SO/Talk", fileName = "TalkSO")]
    public class TalkSO : ScriptableObject
    {
        #region QOL���㏈��
        // �ۑ����Ă���ꏊ�̃p�X
        public const string PATH = "TalkSO";

        // ����
        private static TalkSO _entity;
        public static TalkSO Entity
        {
            get
            {
                // ���A�N�Z�X���Ƀ��[�h����
                if (_entity == null)
                {
                    _entity = Resources.Load<TalkSO>(PATH);

                    // ���[�h�o���Ȃ������ꍇ�̓G���[���O��\��
                    if (_entity == null)
                    {
                        Debug.LogError(PATH + " not found");
                    }
                }

                return _entity;
            }
        }
        #endregion

        [Header("�e�L�X�g�ꗗ")] public List<TextTable> Texts = new List<TextTable>();
        [Header("�e�L�X�g��\������X�s�[�h\n�i�����b���Ƃɕ������X�V���邩�j")] public float CharsShowInterval;
        [Header("�V�����s��\�����n�߂ĉ��b�o������X�L�b�v�\�ɂ��邩")] public float SkipTime;
        [Header("�X�L�b�v�̓��͂��A���b���ƂɎ󂯕t���邩")] public float SkipInterval;
        [Header("���������SE")] public AudioClip CaptionSE;
        [Header("�t�F�[�h�A�E�g���J�n���Ă���V�[���؂�ւ��܂ł̕b��")] public float FadeOutDuration;

        public TextTable GetTextTable(string sceneName)
        {
            foreach (TextTable textTable in Texts)
            {
                if (textTable.SceneName == sceneName)
                {
                    return textTable;
                }
            }

            Debug.LogError("<color=red>�e�L�X�g�̎擾���s</color>");
            return null;
        }
    }

    [Serializable]
    public class TextTable
    {
        [Header("�V�[����")] public string SceneName;
        [Header("�\�����I�������ǂ̃V�[���ɑJ�ڂ��邩")] public string ToSceneName;
        [Header("�e�L�X�g")][TextArea(1, 1000)] public string Text;
    }
}
