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
        //���Ԃ��J�E���g�_�E������
        CountDown -= Time.deltaTime;

        //���Ԃ�\������
        TimeOverText.text = "�����؂�! "+CountDown.ToString("f0") + "�b";

        //countdown��0�ȉ��ɂȂ����Ƃ�
        if (CountDown <= 0)
        {


            SceneManager.LoadScene(SceanName);


            
        }
    }
}
