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

        [Header("Talk�V�[��")] public string[] TalkSceneNames;
    }
}
