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
    }
}

