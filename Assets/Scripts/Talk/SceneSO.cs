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
