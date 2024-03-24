using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using General;

namespace Talk
{
    public class SoundVolumeChanger : MonoBehaviour
    {
        enum SoundType { BGM, SE };
        [SerializeField] SoundType soundType;

        Slider slider;
        float min;
        float max;

        void Start()
        {
            min = GeneralSO.Entity.minVolume;
            max = GeneralSO.Entity.maxVolume;

            slider = GetComponent<Slider>();
            GeneralSO.Entity.AudioMixer.GetFloat(soundType.ToString() + "Param", out float nowVolume);
            slider.value = (slider.maxValue - slider.minValue) / (max - min) * (nowVolume - min) + slider.minValue;
        }

        void Update()
        {
            float volume = (max - min) / (slider.maxValue - slider.minValue) * (slider.value - slider.minValue) + min;
            GeneralSO.Entity.AudioMixer.SetFloat(soundType.ToString() + "Param", volume);
        }
    }
}
