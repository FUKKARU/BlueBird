using Battle;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gollira_RockMov : MonoBehaviour
{
    [NonSerialized] public bool onThrow = false;
    [NonSerialized] public GameObject target;
    GameObject Oya;
    void Start()
    {
        this.gameObject.transform.parent = Oya.gameObject.transform;
    }


    void Update()
    {
        GoToTarget();
        ActiveRegion();
    }

    public void Gollira_RockSet(GameObject Oya_IN)
    {
        Oya = Oya_IN;
    }

    public void Gollira_RockDetach()
    {

            this.gameObject.transform.parent = null;
            onThrow = true;

    }

    void GoToTarget()
    {
        if (onThrow)
        {
            if (target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 10 * Time.deltaTime);
            }
            else Destroy(this.gameObject);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && onThrow)
        {
            Camera camera = Camera.main;
            if (camera != null) camera.GetComponent<ScreenShake>().ShakeOn();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    void ActiveRegion() { if (transform.position.x > 10 || transform.position.y > 10 || transform.position.y < -10) Destroy(gameObject); }

}
