using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

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
        [Space(25)]
        [Header("BGM")] public BGMTable BGM;
        [Header("SE")] public SETable SE;
        [Space(25)]
        [Header("�t�F�[�h�A�E�g���J�n���Ă���V�[���؂�ւ��܂ł̕b��")] public float FadeOutDuration;
    }

    [Serializable]
    public class BGMTable
    {
        [Header("�O���[�v")] public AudioMixerGroup Group;
        [Header("�^�C�g����BGM")] public AudioInfoTable TitleBGM;
        [Header("�G����O����BGM")] public AudioInfoTable PawnBattleBeforeBGM;
        [Header("�G����㔼��BGM")] public AudioInfoTable PawnBattleAfterBGM;
        [Header("�{�X���BGM")] public AudioInfoTable BossBattleBGM;
        [Header("�g�[�N��BGM")] public AudioInfoTable TalkBGM;
    }

    [Serializable]
    public class SETable
    {
        [Header("�O���[�v")] public AudioMixerGroup Group;
        [Header("����SE")] public AudioInfoTable ExplosionSE;
        [Header("�Q�[���I�[�o�[�ɂȂ���SE")] public AudioInfoTable GameOverSE;
        [Header("�G����F�G���U��������SE")] public AudioInfoTable OnPawnBattleEnemyStartAttackSE;
        [Header("�G����F�G�̍U���ɓ�����SE")] public AudioInfoTable OnPawnBattleHitSE;
        [Header("�{�X��F�G���U��������SE")] public AudioInfoTable OnBossBattleEnemyStartAttackSE;
        [Header("�{�X��F�G�̍U���ɓ�����SE")] public AudioInfoTable OnBossBattleHitSE;
        [Header("�g�[�N�F���������SE")] public AudioInfoTable OnTalkCaptionSE;
    }

    [Serializable]
    public class AudioInfoTable
    {
        [FormerlySerializedAs("clip")][Header("�����t�@�C��")] public AudioClip Clip;
        [Header("����"), Range(0, 1)] public float DefaultSoundVolume;
    }
}

