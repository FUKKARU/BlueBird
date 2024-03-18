using System;
using System.Collections.Generic;
using UnityEngine;

namespace Talk
{
    [CreateAssetMenu(menuName = "SO/Talk/Scene", fileName = "SceneSO")]
    public class SceneSO : ScriptableObject
    {
        #region QOL向上処理
        // 保存してある場所のパス
        public const string PATH = "Talk/SceneSO";

        // 実体
        private static SceneSO _entity;
        public static SceneSO Entity
        {
            get
            {
                // 初アクセス時にロードする
                if (_entity == null)
                {
                    _entity = Resources.Load<SceneSO>(PATH);

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

        [Header("テキスト一覧")] public List<TextTable> Texts = new List<TextTable>();
        [Header("テキストを表示するスピード\n（＝何秒ごとに文字を更新するか）")] public float CharsShowInterval;
        [Header("新しい行を表示し始めて何秒経ったらスキップ可能にするか")] public float SkipTime;
        [Header("文字送りのSE")] public AudioClip CaptionSE;

        public string GetText(string sceneName)
        {
            foreach (TextTable textTable in Texts)
            {
                if (textTable.SceneName == sceneName)
                {
                    return textTable.Text;
                }
            }

            return "テキストの取得失敗";
        }
    }

    [Serializable]
    public class TextTable
    {
        [Header("シーン名")] public string SceneName;
        [Header("テキスト")][TextArea(1, 1000)] public string Text;
    }
}
