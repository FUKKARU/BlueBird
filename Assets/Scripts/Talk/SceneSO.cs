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

        [Header("Talkシーン")] public string[] TalkSceneNames;
    }
}
