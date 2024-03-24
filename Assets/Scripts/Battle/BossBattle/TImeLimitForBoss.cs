using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TImeLimitForBoss : MonoBehaviour
{
    [SerializeField]
    private float CountDown = 120f;
    [SerializeField]
    private string SceanName;
    [SerializeField]
    private TextMeshProUGUI TimeOverText;
    




    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        //時間をカウントダウンする
        CountDown -= Time.deltaTime;

        //時間を表示する
        TimeOverText.text = "逃げ切れ! "+CountDown.ToString("f0") + "秒";

        //countdownが0以下になったとき
        if (CountDown <= 0)
        {


            SceneManager.LoadScene(SceanName);


            
        }
    }
}
