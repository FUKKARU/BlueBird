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
    [SerializeField] GameObject hitEffect;
    GameObject Oya;


    void Start()
    {
        this.gameObject.transform.parent = Oya.gameObject.transform;
    }


    void Update()
    {
        Debug.Log(gameObject.name + "  " + onThrow);
        GoToTarget();
        ActiveRegion();
    }

    public void Gollira_RockSet(GameObject Oya_IN)
    {
        Oya = Oya_IN;
    }

    public void Gollira_RockDetach()
    {
        if(gameObject != null) 
        {
            this.gameObject.transform.parent = null;
            onThrow = true;
        }



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

        if (collision.gameObject.tag == "Enemy"  && onThrow)
        {

            Instantiate(hitEffect, (transform.position + collision.transform.position)/2 , Quaternion.identity );
            Camera camera = Camera.main;
            if (camera != null) camera.GetComponent<ScreenShake>().ShakeOn();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "Enemy" && !onThrow)
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
            Debug.Log("hitx");
            StartCoroutine(Check(collision.gameObject));
        }
        else if(collision.gameObject.tag == "BlueBird")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
            Debug.Log("hitb");
        }

    }

    IEnumerator Check( GameObject e)
    {
        yield return new WaitForSeconds(1);
        float dis = Vector3.Distance(e.transform.position, gameObject.transform.position);
        Debug.Log(dis + "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        Debug.Log(onThrow + "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        if(dis < 2 && onThrow)
        {
            Instantiate(hitEffect, (transform.position + e.transform.position) / 2, Quaternion.identity);
            Camera camera = Camera.main;
            if (camera != null) camera.GetComponent<ScreenShake>().ShakeOn();
            Destroy(e);
            Destroy(this.gameObject);
        }
        
        
        yield return null;
    }

    void ActiveRegion() { if (transform.position.x > 10 || transform.position.y > 10 || transform.position.y < -10) Destroy(gameObject); }

}
