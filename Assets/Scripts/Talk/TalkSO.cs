using System;
using System.Collections.Generic;
using UnityEngine;

namespace Talk
{
    [CreateAssetMenu(menuName = "SO/Talk", fileName = "TalkSO")]
    public class TalkSO : ScriptableObject
    {
        #region QOL向上処理
        // 保存してある場所のパス
        public const string PATH = "TalkSO";

        // 実体
        private static TalkSO _entity;
        public static TalkSO Entity
        {
            get
            {
                // 初アクセス時にロードする
                if (_entity == null)
                {
                    _entity = Resources.Load<TalkSO>(PATH);

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
        [Header("スキップの入力を、何秒ごとに受け付けるか")] public float SkipInterval;
        [Header("文字送りのSE")] public AudioClip CaptionSE;
        [Header("フェードアウトを開始してからシーン切り替えまでの秒数")] public float FadeOutDuration;

        public TextTable GetTextTable(string sceneName)
        {
            foreach (TextTable textTable in Texts)
            {
                if (textTable.SceneName == sceneName)
                {
                    return textTable;
                }
            }

            Debug.LogError("<color=red>テキストの取得失敗</color>");
            return null;
        }
    }

    [Serializable]
    public class TextTable
    {
        [Header("シーン名")] public string SceneName;
        [Header("表示が終わったらどのシーンに遷移するか")] public string ToSceneName;
        [Header("テキスト")][TextArea(1, 1000)] public string Text;
    }
}
