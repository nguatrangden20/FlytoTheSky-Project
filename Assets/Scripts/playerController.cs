using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using EZCameraShake;

public class playerController : MonoBehaviour
{
    [SerializeField] ParticleSystem [] particleSystems;

    private float checkForce = 0;
    private float horizontalInput;
    private bool activeMove;
    public bool activeDR;
    private bool checkSpace;
    private bool checkLauching;
    private bool checkPressF;
    private float fade = 0;
    private GameManager gameManagerScript;
    private Slider sliderStartBar;
    private Rigidbody playerRb;
    [SerializeField] GameObject [] explosion; 
    [SerializeField] Material [] shipParts;
    [SerializeField] GameObject cloudImage;
    [SerializeField] Material skybox;
    public GameObject startBar;  
    public GameObject warning;
     
   
   
    private void Awake() 
    {        
        foreach (var sp in shipParts)
        {
            sp.SetFloat("_Fade", 0);
        } 
    }
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManagerScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        sliderStartBar = startBar.GetComponent<Slider>();
        AudioManager.instance.Play("Wind");
    }

    void Update()
    {
        SliderLauch();
        Move();
        if(cloudImage != null ) cloudImage.transform.Translate(Vector3.left * Time.deltaTime);
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * .25f);
        if( checkForce < 8000 && checkLauching ) 
        {
            checkForce += Time.time;
            playerRb.AddRelativeForce(Vector3.left * Time.time);
        }        
    }
    
    public void SpecialMode(InputAction.CallbackContext value)
    {
        if (checkLauching && !checkPressF)
        {
            gameManagerScript.Camera2D();
            checkPressF = !checkPressF;
            activeMove = true;
            AudioManager.instance.Stop("PressF");
            GetComponent<AudioSource>().Stop();
            AudioManager.instance.Play("MusicAction");
            AudioManager.instance.Play("SpaceLauching");
            Destroy(GameObject.Find("PressF"));
            Destroy(cloudImage);            
        }
    }

    public void Launch(InputAction.CallbackContext value)
    {                      
        horizontalInput = value.ReadValue<float>();                                           
    }
    
    public void LaunchPressed(InputAction.CallbackContext value)
    {   
        if(sliderStartBar.IsActive())
        {
            if(value.started)
            {
                checkSpace = true;
                AudioManager.instance.Play("UI2");
            }
        
            if(value.canceled) 
            {
                checkSpace = false;
                AudioManager.instance.Stop("UI2");
            }
        }
    }

    private void StartLaunching()
    {

                    gameManagerScript.cameraIntro.SetActive(false);
                    gameManagerScript.Camera3d();
                    foreach (var pSystems in particleSystems)
                    {
                        pSystems.Play();
                    }
                    playerRb.AddRelativeForce(Vector3.left * 600);
                    CameraShaker.GetInstance("CM vcam1 3D").ShakeOnce(10f, 10f, 2f, 2f);                    
                    checkLauching =! checkLauching;                    
                    gameManagerScript.CameraIntroAnim();
                    AudioManager.instance.Stop("UI2");
                    AudioManager.instance.Stop("Wind");
                    GetComponent<AudioSource>().Play();                    
                    startBar.SetActive(false);
                    gameManagerScript.spaceShuttle.LeanMoveLocalY(152, 70);
    }

    private void SliderLauch()
    {
        
        if(checkSpace && !checkLauching)
        {
            sliderStartBar.value += Time.deltaTime;
            if(sliderStartBar.value >= 1) StartLaunching();
        }

        if (!checkSpace)
        {
            
            sliderStartBar.value -= Time.deltaTime;
        }
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.name == "PressF") AudioManager.instance.Play("PressF");
        if(other.name == "ActiveSpecialMode") StartCoroutine(GameObject.FindGameObjectWithTag("Manager").GetComponent<SpawnManager>().WailtSpawnObjects(1.5f));
        if(other.tag == "DI") 
        {
            gameManagerScript.Camera3d();
        }
        if(other.name == "ChangeBG") 
        {
            activeMove = false;
            gameManagerScript.CameraView();
            RenderSettings.skybox = skybox;           
        }
        if(other.name == "ActiveWarning(Clone)")
        {
            Destroy(GameObject.FindGameObjectWithTag("DI"));
            activeDR = true;
            gameManagerScript.Camera3d();            
            warning.SetActive(true);
            AudioManager.instance.Play("Warning");
            AudioManager.instance.Stop("MusicAction");
            AudioManager.instance.Play("Please");
            Invoke("Explosion", AudioManager.instance.ClipLength("Warning"));
        };
    }

    

    private void Move()
    {
        if (activeMove) transform.Translate(Vector3.up * -horizontalInput * 120 * Time.deltaTime);
    }

    private IEnumerator Explosion(float second)
    {
        for (int i = 0; i < explosion.Length; i++)
        {
            explosion[i].SetActive(true);
            yield return new WaitForSeconds(second);
        }
    }

    public void Explosion()
    {
        StartCoroutine(Explosion(.3f));
        StartCoroutine(Fade(.02f));
        foreach (var pSystems in particleSystems)
        {
            pSystems.Stop();
        }
        playerRb.velocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;
        AudioManager.instance.Play("Explosion");
        AudioManager.instance.Stop("SpaceLauching");
        AudioManager.instance.Stop("PressF");
        GetComponent<AudioSource>().Stop();
        DebugController.gameOver = true;
        gameManagerScript.RestartGame();
        AudioManager.instance.Stop("Please");
        activeMove = false;
        LeanTween.cancel(gameManagerScript.spaceShuttle);
    }

    private void OnCollisionEnter(Collision other) 
    {       
        Explosion();
    }

    IEnumerator Fade(float waitTime) 
    {
        while (fade < 1)
        {
            yield return new WaitForSeconds(waitTime);
            fade += Time.deltaTime;
            if(fade > 1) fade = 1;
            foreach (var sp in shipParts)
            {
                sp.SetFloat("_Fade", fade);
            }
            Destroy(gameObject.GetComponent<BoxCollider>());            
        }
    }
}
