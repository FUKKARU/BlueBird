using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Battle
{
    public class Gollira_ArmMov : MonoBehaviour
    {
        [SerializeField] TweetController tweetController;

        //
        [SerializeField] GameObject rock;
        [SerializeField] Transform rockPos;
        bool hasRockCreated = false;
        bool hasRockThrowed = false;

        float turnDegrees = 0.0f;

        int turnTimes = 0;//òrÇâÒÇµÇΩâÒêîÅ@âÒÇµèâÇﬂÇ…â¡éZ
        int throwedRockNum = 0;//ìäÇ∞ÇÍÇΩä‚ÇÃêîÅ@ìäÇ∞ÇΩéûÇ…â¡éZ

        float t;
        float d = 0;
        void Update()
        {

            if (tweetController.specialActionGollira)
            {
                GolliraArmRotation();
                t += Time.deltaTime;

            }
            else
            {

                d = 0;
                if (!hasRockCreated && turnTimes == throwedRockNum && transform.parent.gameObject.transform.position.y < -6.15f)
                {

                    RockCreate();
                    turnTimes++;
                    hasRockCreated = true;
                }

            }
        }

        void GolliraArmRotation()
        {
            turnDegrees = 360 * Time.deltaTime;
            d += turnDegrees;
            //Debug.Log(d);
            if (d > 360)
            {
                d = 360;
                hasRockThrowed = false;
            }

            if (d > 40 && d < 50 && !hasRockThrowed)
            {
                RockThrow();
                hasRockThrowed = true;

            }

            Quaternion rot = Quaternion.AngleAxis(d, transform.forward);
            transform.rotation = rot;
        }

        Gollira_RockMov createdRock;
        void RockCreate()
        {
            createdRock = Instantiate(rock, rockPos.position, Quaternion.identity).GetComponent<Gollira_RockMov>();
            createdRock.Gollira_RockSet(this.gameObject);
        }
        void RockThrow()
        {
            throwedRockNum++;
            string scene = SceneManager.GetActiveScene().name;
            if (scene == "PawnBattle_noTweet" || scene == "PawnBattle_Tweet" )
            {
                GameObject tezla = FindObjectOfType<Tezla>().gameObject;
                createdRock.target = tezla;
            }
            else if (scene == "BossBattle")
            {
                GameObject spaceZ = FindObjectOfType<SpaceZ>().gameObject;
                createdRock.target = spaceZ;
            }
            
            if (createdRock != null)
            {
                createdRock.Gollira_RockDetach();
            }

            hasRockCreated = false;
        }
    }
}

