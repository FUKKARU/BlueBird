using General;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Battle
{
    public class BGMPlayer : MonoBehaviour
    {
        [SerializeField] AudioSource bgmAs;

        void Start()
        {
            bgmAs.playOnAwake = false;
            bgmAs.loop = true;

            string sceneName = SceneManager.GetActiveScene().name;
            switch (sceneName)
            {
                case "PawnBattle_noTweet":
                    bgmAs.clip = GeneralSO.Entity.BGM.PawnBattleBeforeBGM.Clip;
                    bgmAs.volume = GeneralSO.Entity.BGM.PawnBattleBeforeBGM.DefaultSoundVolume;
                    break;

                case "PawnBattle_Tweet":
                    bgmAs.clip = GeneralSO.Entity.BGM.PawnBattleAfterBGM.Clip;
                    bgmAs.volume = GeneralSO.Entity.BGM.PawnBattleAfterBGM.DefaultSoundVolume;
                    break;

                case "BossBattle":
                    bgmAs.clip = GeneralSO.Entity.BGM.BossBattleBGM.Clip;
                    bgmAs.volume = GeneralSO.Entity.BGM.BossBattleBGM.DefaultSoundVolume;
                    break;
            }

            bgmAs.outputAudioMixerGroup = GeneralSO.Entity.BGM.Group;


            bgmAs.Play();
        }
    }
}
