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
            float defaultVolume = (min + max) / 2;
            GeneralSO.Entity.AudioMixer.SetFloat(soundType.ToString() + "Param", defaultVolume);

            slider = GetComponent<Slider>();
            slider.value = (slider.minValue + slider.maxValue) / 2;
        }

        void Update()
        {
            float value = slider.value;
            float volume = (max - min) / 10 * value + min;
            GeneralSO.Entity.AudioMixer.SetFloat(soundType.ToString() + "Param", volume);
        }
    }
}
