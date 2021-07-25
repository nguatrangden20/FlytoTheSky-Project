using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{


    
    [SerializeField] GameObject[] objectsPrefab;
    [SerializeField] GameObject ship;

    public IEnumerator WailtSpawnObjects(float wailtTime)
    {
        for (int i = 0; i < objectsPrefab.Length; i++)
        {
            SpawnObjects(i);                                
            yield return new WaitForSeconds (wailtTime);
            if (i > 9 & i < 14) yield return new WaitForSeconds(.3f);
            //if(i == 14) FindObjectOfType<playerController>().dI = true;
        }
        Destroy(GameObject.FindGameObjectWithTag("Evironment"));
    }

    private float spawnPosY = 500;
    private void SpawnObjects(int index)
    {
        //int objectsIndex = Random.Range(0, objectsPrefab.Length);
        Vector3 spawn = new Vector3(ship.transform.position.x, ship.transform.position.y + spawnPosY, ship.transform.position.z);
        Instantiate(objectsPrefab[index], spawn, objectsPrefab[index].transform.rotation);
    }
}
