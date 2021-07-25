using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIntro : MonoBehaviour
{
    [SerializeField] GameObject cameraIntroUI;


    public void CameraIntroUI()
    {
        cameraIntroUI.SetActive(false);
    }
}
