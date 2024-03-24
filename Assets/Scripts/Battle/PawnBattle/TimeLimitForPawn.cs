using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeLimitForPawn : MonoBehaviour
{
    [SerializeField]
    private float CountDown = 120f,  SecondCountDown = 125f, ZeroCount;
    [SerializeField]
    private string SceanName;
    [SerializeField]
    private TextMeshProUGUI TimeOverText;
    [SerializeField]
    private GameObject TweetButton;
    



    void Start()
    {
        //TweetButton.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //���Ԃ��J�E���g�_�E������
        CountDown -= Time.deltaTime;

        //���Ԃ�\������
        TimeOverText.text = CountDown.ToString("f0") + "�b";

        //countdown��0�ȉ��ɂȂ����Ƃ�
        if (CountDown <= 0)
        {
            SceneManager.LoadScene(SceanName);
            /*
            TweetButton.SetActive(true);
            CountDown = SecondCountDown;
            ZeroCount += 1;
            if (ZeroCount == 2)
            {               
                SceneManager.LoadScene(SceanName);
            }
            */
        }
    }
}
