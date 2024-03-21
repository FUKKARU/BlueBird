using Battle;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum ATTACKER{
    GOLLIRA,
    YOUSEI
}

namespace Battle 
{
    public class TweetController : MonoBehaviour
    {
        bool onAttack = false;

        [NonSerialized] public bool specialActionGollira = false;//trueÇÃéûÉSÉäÉâÇ™òrÇêUÇ¡Çƒä‚ÇìäÇ∞ÇÈ
        bool onSpecialAttack = false;


        [SerializeField] GameObject gollira;
        [SerializeField] Transform gollira_startPos;
        [SerializeField] Transform gollira_endPos;

        [SerializeField] GameObject yousei;
        [SerializeField] Transform yousei_startPos;
        [SerializeField] Transform yousei_endPos;

        [SerializeField] AnimationCurve curve;

        ATTACKER attacker;



        public void Tweet()
        {
            if (!onAttack)
            {
                int rand = UnityEngine.Random.Range(0,2);
                if(rand == 0) attacker = ATTACKER.GOLLIRA;
                else if(rand == 1) attacker = ATTACKER.YOUSEI;

                switch (attacker)
                {
                    case ATTACKER.GOLLIRA:
                        StartCoroutine( Attack (gollira, gollira_startPos, gollira_endPos) );
                        break;
                    
                    case ATTACKER.YOUSEI:
                        StartCoroutine( Attack (yousei, yousei_startPos, yousei_endPos) );
                        break;
                    
                    default:
                        Debug.LogError("ó\ä˙ÇπÇ ÉpÉ^Å[ÉìÅ@TweetController.cs line 41");
                        break;

                }
                
            }
        }

        IEnumerator Attack(GameObject attacker, Transform startPos, Transform endPos)
        {
            onAttack = true;
            float time = 0;
            while (time <= 3)
            {
                if (time > 1 && !onSpecialAttack)
                {
                    if(attacker == gollira)
                    {
                        specialActionGollira = true;
                    }
                    
                    onSpecialAttack = true;
                }
                if (time > 2 && onSpecialAttack)
                {
                    if(attacker == gollira)
                    {
                        specialActionGollira = false;
                    }
                    
                    onSpecialAttack = false;
                }
                attacker.transform.position = Vector3.Lerp(startPos.position, endPos.position, curve.Evaluate(time));
                yield return new WaitForSeconds(0.01f);
                time += 0.01f;
            }
            onAttack = false;

            yield return null;

        }
    }
}


