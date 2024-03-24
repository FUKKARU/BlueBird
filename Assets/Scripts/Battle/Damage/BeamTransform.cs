using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamTransform : MonoBehaviour
{
    [SerializeField]
    private GameObject ForMove;
    [SerializeField]
    private Vector3 RotateBefore = new Vector3(0, 0, -66f), RotateAfter = new Vector3(0, 0, 17f);
    [SerializeField]
    private float Speed = 1.5f, RandomTime, i, time = 5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        

        if (time <= 0)
        {
            ForMove.transform.Rotate(RotateBefore);
            ForMove.SetActive(true);
            ForMove.transform.Rotate(RotateAfter * Speed);
        }

    }

}
