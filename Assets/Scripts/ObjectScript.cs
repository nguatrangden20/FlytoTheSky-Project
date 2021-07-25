using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{

    private void Start() 
    {
        StartCoroutine(MoveDestroy());
    }

    IEnumerator MoveDestroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

}
