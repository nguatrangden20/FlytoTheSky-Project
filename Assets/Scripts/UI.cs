using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
   
    [SerializeField] Material startBoder;
    [SerializeField] Material winBorder;

    private float fade = 1;

    private void Awake() 
    {
        winBorder.SetFloat("_Fade", 1);
        startBoder.SetFloat("_Fade", 1);
    }


    public void TurnOnUI()
    {
        StartCoroutine(Fade(.02f));
    }

    IEnumerator Fade(float waitTime) 
    {
        while (fade > 0)
        {
            yield return new WaitForSeconds(waitTime);
            fade -= Time.deltaTime;
            if(fade <= 0) fade = 0;
            winBorder.SetFloat("_Fade", fade);
            startBoder.SetFloat("_Fade", fade);
        }
        //fade = 0;
    }
}
