using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace General
{
    [CreateAssetMenu(menuName = "SO/General", fileName = "GeneralSO")]
    public class GeneralSO : ScriptableObject
    {
        #region QOL向上処理
        // 保存してある場所のパス
        public const string PATH = "GeneralSO";

        // 実体
        private static GeneralSO _entity;
        public static GeneralSO Entity
        {
            get
            {
                // 初アクセス時にロードする
                if (_entity == null)
                {
                    _entity = Resources.Load<GeneralSO>(PATH);

                    // ロード出来なかった場合はエラーログを表示
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
        [Header("最低音量（db）")] public float minVolume;
        [Header("最大音量（db）")] public float maxVolume;
        [Space(25)]
        [Header("BGM")] public BGMTable BGM;
        [Header("SE")] public SETable SE;
    }

    [Serializable]
    public class BGMTable
    {
        [Header("タイトルのBGM")] public AudioInfoTable TitleBGM;
        [Header("雑魚戦前半のBGM")] public AudioInfoTable PawnBattleBeforeBGM;
        [Header("雑魚戦後半のBGM")] public AudioInfoTable PawnBattleAfterBGM;
        [Header("ボス戦のBGM")] public AudioInfoTable BossBattleBGM;
        [Header("トークのBGM")] public AudioInfoTable TalkBGM;
    }

    [Serializable]
    public class SETable
    {
        [Header("爆発SE")] public AudioInfoTable ExplosionSE;
        [Header("ゲームオーバーになったSE")] public AudioInfoTable GameOverSE;
        [Header("雑魚戦：敵が攻撃をするSE")] public AudioInfoTable OnPawnBattleEnemyStartAttackSE;
        [Header("雑魚戦：敵の攻撃に当たるSE")] public AudioInfoTable OnPawnBattleHitSE;
        [Header("ボス戦：敵が攻撃をするSE")] public AudioInfoTable OnBossBattleEnemyStartAttackSE;
        [Header("ボス戦：敵の攻撃に当たるSE")] public AudioInfoTable OnBossBattleHitSE;
        [Header("トーク：文字送りのSE")] public AudioInfoTable OnTalkCaptionSE;
    }

    [Serializable]
    public class AudioInfoTable
    {
        [Header("音源ファイル")] public AudioClip clip;
        [Header("音量"), Range(0, 1)] public float DefaultSoundVolume;
    }
}

