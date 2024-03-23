using Battle;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


enum ATTACKER{
    GOLLIRA,
    YOUSEI,
    LIGHTNING

}

namespace Battle 
{
    public class TweetController : MonoBehaviour
    {
        bool onAttack = false;

        [NonSerialized] public bool specialActionGollira = false;//trueの時ゴリラが腕を振って岩を投げる
        bool onSpecialAttack = false;

        [SerializeField] GameObject effHit;


        [SerializeField] GameObject gollira;
        [SerializeField] Transform gollira_startPos;
        [SerializeField] Transform gollira_endPos;
        [SerializeField] AudioClip golliraSE;

        [SerializeField] GameObject yousei;
        [SerializeField] Transform yousei_startPos;
        [SerializeField] Transform yousei_endPos;
        [SerializeField] AudioClip youseiSE;

        [SerializeField] GameObject lightning;
        [SerializeField] AudioClip lightningSE;
        [SerializeField] YellowImage yellowImage;
        bool SE_Happend = false;

        [SerializeField] AnimationCurve curve;

        [SerializeField] GameObject blueBird;

        [SerializeField] GameObject tweetVideo;
        [SerializeField] AudioClip tweetVideoSE;
        [SerializeField] GreenImage recoverImage;
        ATTACKER attacker;

        [SerializeField] Button tweetButton;

        [SerializeField] AudioSource aS;

        private void Start()
        {
            lightning.GetComponent<SpriteRenderer>().color = new Color(1, 0.9408277f, 0.5440251f, 0);
        }


        public void Tweet()
        {
            if (!onAttack)
            {
                if (blueBird != false)
                {

                    tweetVideo.GetComponent<VideoPlayer>().Play();
                    aS.PlayOneShot(tweetVideoSE);
                    Debug.Log("S");
                }

                int rand = UnityEngine.Random.Range(0,3);
                if (rand == 0) attacker = ATTACKER.GOLLIRA;
                else if (rand == 1) attacker = ATTACKER.YOUSEI;
                else if (rand == 2) attacker = ATTACKER.LIGHTNING;

                switch (attacker)
                {
                    case ATTACKER.GOLLIRA:
                    StartCoroutine( Attack (gollira, gollira_startPos, gollira_endPos) );
                    break;
                    
                    case ATTACKER.YOUSEI:
                    StartCoroutine( Attack (yousei, yousei_startPos, yousei_endPos) );
                    break;

                    case ATTACKER.LIGHTNING:
                        StartCoroutine(Attack(lightning,lightning.transform,lightning.transform));
                    break;

                    default:
                    //Debug.LogError("予期せぬパターン　TweetController.cs line 56");
                    break;

                }
                
            }
        }

        IEnumerator Attack(GameObject attacker, Transform startPos, Transform endPos)
        {
            tweetButton.image.color = new Color(1,1,1,0.6f);
            onAttack = true;
            float time = 0;
            while (time <= 3)
            {
                if(attacker == lightning)
                {
                    if (time < 0.5f)
                    {
                        if (!SE_Happend)
                        {
                            lightning.GetComponent<SpriteRenderer>().color = new Color(1, 0.9408277f, 0.5440251f, 1);
                            aS.PlayOneShot(lightningSE);
                            yellowImage.YellowScreen();
                            SE_Happend = true;

                        }

                        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                        foreach (GameObject enemy in enemies)
                        {
                            if (enemy.transform.position.x > -8.4)
                            {
                                Instantiate(effHit, enemy.transform.position, Quaternion.identity);
                                Destroy(enemy);
                            }
                        }
                    }
                    else
                    {
                        lightning.GetComponent<SpriteRenderer>().color = new Color(1, 0.9408277f, 0.5440251f, 0);
                        SE_Happend = false;
                    }
                }
                else
                {
                    if (time > 1 && time < 1.5f && !onSpecialAttack)
                    {
                        if (attacker == gollira)
                        {
                            specialActionGollira = true;
                            aS.PlayOneShot(golliraSE);
                        }

                        if (attacker == yousei && blueBird != null)
                        {
                            blueBird.GetComponent<BlueBirdStatus>().Heal(20f);
                            recoverImage.GreenScreen();
                            aS.PlayOneShot(youseiSE);
                            //Debug.Log("heal");
                        }

                        onSpecialAttack = true;
                    }
                    if (time > 2 && onSpecialAttack)
                    {
                        if (attacker == gollira)
                        {
                            specialActionGollira = false;
                        }

                        onSpecialAttack = false;
                    }
                    attacker.transform.position = Vector3.Lerp(startPos.position, endPos.position, curve.Evaluate(time));
                }
                
                yield return new WaitForSeconds(0.01f);
                time += 0.01f;
            }

            tweetButton.image.color = new Color(1, 1, 1, 1f);
            onAttack = false;
            

            yield return null;

        }


    }
}


