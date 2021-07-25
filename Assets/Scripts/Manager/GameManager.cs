using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject camera3D;
    [SerializeField] GameObject camera2D;
    public GameObject cameraIntro;
    public bool checkRestart;
    public GameObject spaceShuttle;
    [SerializeField] Animator rocket1;
    [SerializeField] Animator rocket2;
    [SerializeField] ParticleSystem friction;
    
    private Animator ladderAnim;
    private Animator cameraIntroAnim;

    private void Start() 
    {
        ladderAnim = GameObject.Find("Cylinder").GetComponent<Animator>();
        cameraIntroAnim = GameObject.Find("Camera Intro").GetComponent<Animator>();
    }

    public void Camera3d()
    {        
        camera2D.SetActive(false);
        camera3D.SetActive(true);
        camView.SetActive(false);
    }

    public void Camera2D()
    {
        camera2D.SetActive(true);
        camera3D.SetActive(false);
    }

    [SerializeField] GameObject camView;
    public void CameraView()
    {        
        camView.SetActive(true);
        camera3D.SetActive(false);
    }

    public void BootSystems()
    {
        ladderAnim.SetTrigger("Move");
        AudioManager.instance.Play("UI");
        FindObjectOfType<UI>().TurnOnUI();
        spaceShuttle.transform.LeanMoveLocal(new Vector2(-333, -168), 1);
        FindObjectOfType<playerController>().startBar.SetActive(true);
    }

    public void CameraIntroAnim()
    {
        cameraIntroAnim.SetTrigger("Active");
        GameObject.Find("ImageCameraIntro").transform.LeanScale(new Vector3(1,1,1), 1);
    }

    public void RestartGame()
    {
        GameObject.Find("RestartGame").LeanScale(new Vector3(1, 1, 1), 0.5f);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene((int)SceneIndexs.FTS);
        DebugController.gameOver = false;
        checkRestart = true;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene((int)SceneIndexs.MANAGER);
    }

    public void DischargeRoket()
    {
        if(ship.GetComponent<playerController>().activeDR)
        {
            rocket1.SetTrigger("Active");
            rocket2.SetTrigger("Active");
            AudioManager.instance.Play("RocketSeparation");
            Destroy(GameObject.FindGameObjectWithTag("DI"));
            FindObjectOfType<playerController>().CancelInvoke();
            Destroy(FindObjectOfType<playerController>().warning);
            AudioManager.instance.Stop("Warning");
            StartCoroutine(ChageScene());
            AudioManager.instance.Stop("Please");
        }
    }
    
    [SerializeField] Material sky;
    [SerializeField] GameObject earth;
    [SerializeField] GameObject ship;
    [SerializeField] Material skybox2;
    [SerializeField] GameObject camCreadit;
    [SerializeField] GameObject tank;
    [SerializeField] GameObject anhHoang;
    [SerializeField] GameObject minLazy;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject quit;
    private IEnumerator ChageScene()
    {
        friction.Play();
        yield return new WaitForSeconds(3);
        StartCoroutine(FadeIn());                    
        Vector3 posEarth = new Vector3(ship.transform.position.x, ship.transform.position.y, ship.transform.position
        .z);
        Instantiate(earth, posEarth, earth.transform.rotation); 
        Destroy(GameObject.Find("CameraUI"));
    }

    private IEnumerator FadeIn()
    {     
        RenderSettings.skybox = skybox2;
        float elapsedTime = 1;
        while (elapsedTime <= 8f)
        {
            elapsedTime += Time.unscaledDeltaTime * 2;
            RenderSettings.skybox.SetFloat("_Exposure", elapsedTime);
            RenderSettings.ambientIntensity = elapsedTime;
            yield return null;
        }
        ship.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ship.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ship.transform.rotation = Quaternion.Euler(-45, 180, -90);        
        Vector3 localVelocity = ship.transform.InverseTransformDirection(ship.GetComponent<Rigidbody>().velocity);
        localVelocity.x = -20;
        ship.GetComponent<Rigidbody>().velocity = ship.transform.TransformDirection(localVelocity);
        while (elapsedTime >= 1)
        {
            elapsedTime -= Time.unscaledDeltaTime * 2;
            RenderSettings.skybox.SetFloat("_Exposure", elapsedTime);
            RenderSettings.ambientIntensity = elapsedTime;
            yield return null;
        }
        Destroy(friction);
        AudioManager.instance.Stop("SpaceLauching");
        AudioManager.instance.Play("Creadit");
        RenderSettings.skybox = sky;          
        camCreadit.SetActive(true);
        camera3D.SetActive(false);
        yield return new WaitForSeconds(3);
        tank.AddComponent<Rigidbody>();
        AudioManager.instance.Play("RocketSeparation"); 
        anhHoang.SetActive(true);
        quit.SetActive(true);
        yield return new WaitForSeconds(8);
        minLazy.SetActive(true);
        yield return new WaitForSeconds(8);
        credits.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();        
    }

}