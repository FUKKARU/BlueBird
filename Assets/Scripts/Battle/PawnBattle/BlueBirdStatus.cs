using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueBirdStatus : MonoBehaviour
{
    [SerializeField] Slider hp_slider;
    [SerializeField] Slider hp_diff_slider;
    [SerializeField] float maxHP;
    float hp;
    float timer;

    private void Start()
    {
        hp = maxHP;
        timer = 0;
    }

    private void Update()
    {
        if (hp <= 0)
            gameObject.SetActive(false);

        hp_diff_slider.value = Mathf.Lerp(hp_diff_slider.value, hp_slider.value, timer);
        timer += 0.1f * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
            Hit();
    }

    private void Hit()
    {
        hp -= 5f;
        hp_slider.value = hp / maxHP;
        timer = 0;
    }
}
