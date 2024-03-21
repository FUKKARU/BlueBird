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

        int turnTimes = 0;//˜r‚ð‰ñ‚µ‚½‰ñ”@‰ñ‚µ‰‚ß‚É‰ÁŽZ
        int throwedRockNum = 0;//“Š‚°‚ê‚½Šâ‚Ì”@“Š‚°‚½Žž‚É‰ÁŽZ

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
                if (!hasRockCreated@&& turnTimes == throwedRockNum)
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

            if(d > 40 && d < 50 && !hasRockThrowed)
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
            if (scene == "PawnBattle")
            {

            }
            else if (scene == "BossBattle")
            {
                GameObject spaceZ = FindObjectOfType<SpaceZ>().gameObject;
                createdRock.target = spaceZ;
            }
            createdRock.Gollira_RockDetach();
            if (createdRock != null)
            {
                
            }

            hasRockCreated = false;
        }
    }
}

