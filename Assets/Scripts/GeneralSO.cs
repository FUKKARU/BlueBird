using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace General
{
    [CreateAssetMenu(menuName = "SO/General", fileName = "GeneralSO")]
    public class GeneralSO : ScriptableObject
    {
        #region QOL���㏈��
        // �ۑ����Ă���ꏊ�̃p�X
        public const string PATH = "GeneralSO";

        // ����
        private static GeneralSO _entity;
        public static GeneralSO Entity
        {
            get
            {
                // ���A�N�Z�X���Ƀ��[�h����
                if (_entity == null)
                {
                    _entity = Resources.Load<GeneralSO>(PATH);

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

        [Header("Audio Mixer")] public AudioMixer AudioMixer;
        [Header("�Œቹ�ʁidb�j")] public float minVolume;
        [Header("�ő剹�ʁidb�j")] public float maxVolume;
    }
}

