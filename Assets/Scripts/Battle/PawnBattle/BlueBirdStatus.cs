using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Battle
{
    public class BlueBirdStatus : MonoBehaviour
    {
        [SerializeField] GameObject FixedJoystick;
        [SerializeField] GameObject TweetButton;
        [SerializeField] GameObject Timer;
        [SerializeField] Slider hp_slider;
        [SerializeField] Slider hp_hit_slider;
        [SerializeField] Slider hp_heal_slider;
        [SerializeField] float maxHP;
        [SerializeField] RedImage redImage;
        [SerializeField] GameObject damageEffect;
        [SerializeField]
        private GameObject DeadMenu;
        float hp;
        float timer;

        [NonSerialized]public float input_HP;

        private void Start()
        {
            hp = maxHP;
            input_HP = hp;
            timer = 0;
            Time.timeScale = 1f;
        }

        private void Update()
        {
            //HealthCont();
            //Debug.Log("hp " + hp);
            //Debug.Log("input_HP " + input_HP);
            if (hp <= 0)
            {
                if (FixedJoystick) FixedJoystick.SetActive(false);
                if (TweetButton) TweetButton.SetActive(false);
                if (Timer) Timer.SetActive(false);
                gameObject.SetActive(false);
                Time.timeScale = 0f;
                DeadMenu.SetActive(true);
            }
            hp_hit_slider.value = Mathf.Lerp(hp_hit_slider.value, hp_slider.value, timer);
            hp_slider.value = Mathf.Lerp(hp_slider.value, hp_heal_slider.value, timer);
            timer += 0.01f * Time.deltaTime;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                redImage.RedScreen();
                Instantiate(damageEffect,transform.position,Quaternion.identity);
                Hit();
                
            }
                
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "Razer")
            {
                HitBullet();

            }
        }

        private void Hit()
        {
            hp -= 15f;
            input_HP -= 15f;
            hp_slider.value = hp / maxHP;
            hp_heal_slider.value = hp / maxHP;
            timer = 0;
        }

        private void HitBullet()
        {
            hp -= 3f;
            input_HP -= 3f;
            hp_slider.value = hp / maxHP;
            hp_heal_slider.value = hp / maxHP;
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

            hp_heal_slider.value = hp / maxHP;
        }

        public void Heal(float amount)
        {
            if (amount >= maxHP - hp)
                amount = maxHP - hp;

            hp += amount;
            hp_heal_slider.value = hp / maxHP;
        }
    }
}