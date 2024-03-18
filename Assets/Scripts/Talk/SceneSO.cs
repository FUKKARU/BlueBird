using System;
using System.Collections.Generic;
using UnityEngine;

namespace Talk
{
    [CreateAssetMenu(menuName = "SO/Talk/Scene", fileName = "SceneSO")]
    public class SceneSO : ScriptableObject
    {
        #region QOL���㏈��
        // �ۑ����Ă���ꏊ�̃p�X
        public const string PATH = "Talk/SceneSO";

        // ����
        private static SceneSO _entity;
        public static SceneSO Entity
        {
            get
            {
                // ���A�N�Z�X���Ƀ��[�h����
                if (_entity == null)
                {
                    _entity = Resources.Load<SceneSO>(PATH);

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

        public string GetText(string sceneName)
        {
            foreach (TextTable textTable in Texts)
            {
                if (textTable.SceneName == sceneName)
                {
                    return textTable.Text;
                }
            }

            return "�e�L�X�g�̎擾���s";
        }
    }

    [Serializable]
    public class TextTable
    {
        [Header("�V�[����")] public string SceneName;
        [Header("�e�L�X�g")][TextArea(1, 1000)] public string Text;
    }
}
