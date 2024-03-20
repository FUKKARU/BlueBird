using Battle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum Attacker{
    gollira,
    yousei
}

namespace Battle 
{
    public class TweetController : MonoBehaviour
    {
        bool onAttack = false;

        [SerializeField] GameObject gollira;
        [SerializeField] Transform gollira_startPos;
        [SerializeField] Transform gollira_endPos;

        [SerializeField] GameObject yousei;
        [SerializeField] Transform yousei_startPos;
        [SerializeField] Transform yousei_endPos;

        [SerializeField] AnimationCurve curve;

        Attacker attacker;



        public void Tweet()
        {
            if (!onAttack)
            {
                int rand = UnityEngine.Random.Range(0,2);
                if(rand == 0) attacker = Attacker.gollira;
                else if(rand == 1) attacker = Attacker.yousei;

                switch (attacker)
                {
                    case Attacker.gollira:
                        StartCoroutine( Attack (gollira, gollira_startPos, gollira_endPos) );
                        break;
                    
                    case Attacker.yousei:
                        StartCoroutine( Attack (yousei, yousei_startPos, yousei_endPos) );
                        break;
                    
                    default:
                        Debug.LogError("予期せぬパターン　TweetController.cs line 41");
                        break;

                }
                
            }
        }

        IEnumerator Attack(GameObject attacker, Transform startPos, Transform endPos)
        {
            onAttack = true;
            float time = 0;
            while (time <= 2)
            {
                attacker.transform.position = Vector3.Lerp(startPos.position, endPos.position, curve.Evaluate(time));
                yield return new WaitForSeconds(0.01f);
                time += 0.01f;
            }
            onAttack = false;
            yield return null;

        }
    }
}


