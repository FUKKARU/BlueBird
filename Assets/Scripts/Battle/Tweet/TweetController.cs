using Battle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Battle 
{
    public class TweetController : MonoBehaviour
    {
        bool onAttack = false;

        [SerializeField] GameObject gollira;
        [SerializeField] Transform gollira_startPos;
        [SerializeField] Transform gollira_endPos;

        [SerializeField] AnimationCurve curve;

        public void Tweet()
        {
            if (!onAttack) StartCoroutine(GolliraAttack());
        }

        IEnumerator GolliraAttack()
        {
            onAttack = true;
            float time = 0;
            while (time <= 2)
            {
                gollira.transform.position = Vector3.Lerp(gollira_startPos.position, gollira_endPos.position, curve.Evaluate(time));
                yield return new WaitForSeconds(0.01f);
                time += 0.01f;
            }
            onAttack = false;
            yield return null;

        }
    }
}


