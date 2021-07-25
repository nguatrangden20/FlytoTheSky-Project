using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugController : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    bool showConsole;
    string input;
    bool isHelpOn;
    public static bool gameOver;

    public static DebugCommand BOOT_SYSTEMS;
    public static DebugCommand HELP;
    public static DebugCommand ROCKET_SEPARATION;
    public static DebugCommand QUIT;
    public static DebugCommand TUTORIAL;

    public List<object> commandList;

    public void OnToggeleDebug(InputAction.CallbackContext value)
    {
        showConsole = !showConsole;
        input = "";
    }       

    public void OnReturn(InputAction.CallbackContext value)
    {
        if(showConsole && !gameOver)
        {
            HandleInput();
            input = "";            
        }
    }

    private void Awake() 
    {

        BOOT_SYSTEMS = new DebugCommand("BS", "KHỞI ĐỘNG TÀU VŨ TRỤ", "BS             ", () =>
        {
            gameManager.GetComponent<GameManager>().BootSystems();
        });

        HELP = new DebugCommand("HELP", "THÔNG TIN CÁC CÂU LỆNH", "HELP       ", () => isHelpOn = true);

        ROCKET_SEPARATION = new DebugCommand("RS", "TÁCH TÊN LỬA ĐẨY", "RS            ", () =>
        {
            gameManager.GetComponent<GameManager>().DischargeRoket();
        });

        QUIT = new DebugCommand("QUIT", "THOÁT TRÒ CHƠI", "QUIT         ", () =>
        {
            Application.Quit(); 
        });

        TUTORIAL = new DebugCommand("TUTORIAL", "HƯỚNG DẪN CHƠI", "TUTORIAL", () =>
        {
            AudioManager.instance.Play("Tutorial");
        });

        commandList = new List<object>
        {
            BOOT_SYSTEMS,
            HELP,
            ROCKET_SEPARATION,
            QUIT,
            TUTORIAL
        };
    }

    private void OnGUI() 
    {
        if (!showConsole) {return;}
        float y = Screen.height;
        GUI.Box(new Rect(0, y/2, Screen.width, Screen.height/2), "");
        GUI.skin.label.fontSize = 30;
        if (isHelpOn == true)
        {
            for (int i = 0; i < commandList.Count; i++)
        {
            DebugCommandBase command = commandList[i] as DebugCommandBase;
            string label = $"{command.commandFormat}            {command.commandDescription}";
            Rect labelRect = new Rect(20, (y/2 + 100) + (50 * i) , Screen.width/2 , 50);
            GUI.Label(labelRect, label);
        }
        }
        GUI.backgroundColor = new Color (1,1,1,1);
        GUI.skin.textField.fontSize = 30;
        GUI.SetNextControlName("Code");
        input = GUI.TextField(new Rect(10f, y/2 + 5f, Screen.width -20f, 50f), input.ToUpper());
        GUI.FocusControl("Code");
    }

    private void HandleInput()
    {
        for (int i = 0; i < commandList.Count; i++)
        {
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;

            if (input.Contains(commandBase.commandID))
            {
                if (commandList[i] as DebugCommand != null) 
                {
                    (commandList[i] as DebugCommand).Invoke();
                }
            }
        }
    }
}
