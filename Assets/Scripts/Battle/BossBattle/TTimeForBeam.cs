using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TTimeForBeam : MonoBehaviour
{
    [SerializeField]
    private float CountDown = 120f;
    [SerializeField]
    private string SceanName;
    [SerializeField]
    private TextMeshProUGUI TimeOverText;
    [SerializeField]
    private GameObject ForMove;
    [SerializeField]
    private Vector3 RotateBefore = new Vector3(0, 0, -66f), RotateAfter = new Vector3(0, 0, 83f);
    [SerializeField]
    private float Speed = 10f, Count = 83,  When = 1, lot = 0;
    [SerializeField]
    private bool RazerShoot = false;






    IEnumerator Start()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(NoLimitRazer());
    }
    // Update is called once per frame
    void Update()
    {
        //時間をカウントダウンする
        CountDown -= Time.deltaTime;

        //時間を表示する
        TimeOverText.text = "逃げ切れ! " + CountDown.ToString("f0") + "秒";

        //countdownが0以下になったとき
        if (CountDown <= 0)
        {


            SceneManager.LoadScene(SceanName);



        }

        
        /*
        if (CountDown <= 55f && lot <= Count)
        {

            ForMove.SetActive(true);
                // ForMove.transform.Rotate(RotateAfter * Speed); 
                ForMove.transform.rotation = Quaternion.Euler(0, 0, lot);
                lot += Time.deltaTime * Speed;
               
        }
            
        if (lot >= Count)
        {
            ForMove.SetActive(false);
            ForMove.transform.rotation = Quaternion.Euler(0, 0, RotateBefore.z);
        }
        */
        
        
            
        
    }

    IEnumerator NoLimitRazer()
    {
        ForMove.SetActive(true);
        float Lot = 0;

        ForMove.transform.rotation = Quaternion.Euler(RotateBefore);
        while (Lot <= 95)
        {
            ForMove.transform.rotation = Quaternion.Euler(0, 0, Lot + RotateBefore.z);
            yield return new WaitForSeconds(0.01f);
            Lot += Speed;

        }

        
        ForMove.SetActive(false);

        yield return new WaitForSeconds(6);
       
        StartCoroutine(NoLimitRazer());

    }
}