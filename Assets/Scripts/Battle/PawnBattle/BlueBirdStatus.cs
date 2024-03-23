using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class BlueBirdStatus : MonoBehaviour
    {
        [SerializeField] Slider hp_slider;
        [SerializeField] Slider hp_diff_slider;
        [SerializeField] float maxHP;
        [SerializeField] RedImage redImage;
        [SerializeField] GameObject damageEffect;
        float hp;
        float timer;

        [NonSerialized]public float input_HP;

        private void Start()
        {
            hp = maxHP;
            input_HP = hp;
            timer = 0;
        }

        private void Update()
        {
            HealthCont();
            Debug.Log("hp " + hp);
            Debug.Log("input_HP " + input_HP);
            if (hp <= 0)
                gameObject.SetActive(false);

            hp_diff_slider.value = Mathf.Lerp(hp_diff_slider.value, hp_slider.value, timer);
            timer += 0.1f * Time.deltaTime;

            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                redImage.RedScreen();
                Instantiate(damageEffect,transform.position,Quaternion.identity);
                Hit();
                
            }
            else if(other.gameObject.CompareTag("EnemyBullet"))
            {
                HitBullet();
            }
                
        }

        private void Hit()
        {
            hp -= 5f;
            input_HP -= 5f;
            hp_slider.value = hp / maxHP;
            timer = 0;
        }

        private void HitBullet()
        {
            hp -= 1f;
            input_HP -= 1f;
            hp_slider.value = hp / maxHP;
            timer = 0;
        }

        void HealthCont()
        {
            if(input_HP >= maxHP)
            {
                input_HP = maxHP;
                hp = input_HP;
            }
            else
            {
                hp = input_HP;
            }
        }
    }
}