using Battle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpaceZCreator : MonoBehaviour
{
    [SerializeField] int repeatSec;
    [SerializeField] GameObject blueBird;
    [SerializeField] SpaceZ spaceZPrefab;
    [SerializeField] RedImage damageImage;

    private void Start()
    {
        StartCoroutine(SpaceZ_create());
    }

    void Update()
    {

    }  

    IEnumerator SpaceZ_create()
    {
        SpaceZ spaceZ = Instantiate(spaceZPrefab,RandomPos(),Quaternion.identity);
        spaceZ.setSpaceZ(blueBird, damageImage);
        yield return new WaitForSeconds(repeatSec);
        StartCoroutine(SpaceZ_create());
        yield return null;
    }

    Vector3 RandomPos()
    {
        Vector3 pos = this.transform.position;
        pos.y = Random.Range(-3.0f,3.0f);
        return pos;
    }
}
