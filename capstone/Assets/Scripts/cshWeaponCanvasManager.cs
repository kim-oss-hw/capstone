using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshWeaponCanvasManager : MonoBehaviour
{
    public GameObject[] rightButtons = new GameObject[3];
    public GameObject[] leftButtons = new GameObject[3];
    public Button toggleButton;
    public Button selectButton;
    public Text toggleButtonText;
    private bool isRight = true;
    public GameObject ovrCamera;
    public GameObject ovrmyplayer;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        ovrCamera = GameObject.Find("OVRPlayerCamera").gameObject;
        transform.GetComponent<OVRRaycaster>().pointer = GameObject.Find("UIHelpers").transform.GetChild(0).gameObject;
        toggleButton.onClick.AddListener(ToggleHand);
        selectButton.onClick.AddListener(CompleteSetting);
        

        player = GameObject.Find("MyPlayer").gameObject;
        if (!player) player =  GameObject.Find("Player").gameObject;
        player.GetComponent<cshSettingWeapon>().rightButtons = ReturnRightButtons();
        player.GetComponent<cshSettingWeapon>().leftButtons = ReturnLeftButtons();
        player.GetComponent<cshSettingWeapon>().selectButton = transform.GetChild(0).GetChild(7).GetComponent<Button>();

        //동기화함수
        player.GetComponent<cshSettingWeapon>().SynchroButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Button[] ReturnRightButtons()
    {
        Button[] buttons = new Button[3];
        buttons[0] = rightButtons[0].GetComponent<Button>();
        buttons[1] = rightButtons[1].GetComponent<Button>();
        buttons[2] = rightButtons[2].GetComponent<Button>();

        return buttons;
    }

    Button[] ReturnLeftButtons()
    {
        Button[] buttons = new Button[3];
        buttons[0] = leftButtons[0].GetComponent<Button>();
        buttons[1] = leftButtons[1].GetComponent<Button>();
        buttons[2] = leftButtons[2].GetComponent<Button>();

        return buttons;
    }

    void ToggleHand()
    {
        if(isRight)
        {
            rightButtons[0].SetActive(false);
            rightButtons[1].SetActive(false);
            rightButtons[2].SetActive(false);
            leftButtons[0].SetActive(true);
            leftButtons[1].SetActive(true);
            leftButtons[2].SetActive(true);

            isRight = false;
            toggleButtonText.text = "현재\n왼손잡이\n(변경버튼)";
        } else
        {
            leftButtons[0].SetActive(false);
            leftButtons[1].SetActive(false);
            leftButtons[2].SetActive(false);
            rightButtons[0].SetActive(true);
            rightButtons[1].SetActive(true);
            rightButtons[2].SetActive(true);

            isRight = true;
            toggleButtonText.text = "현재\n오른손잡이\n(변경버튼)";
        }
    }

    void CompleteSetting()
    {
        if(player.GetComponent<cshSettingWeapon>().isEquiped())
        {
            ovrCamera.GetComponent<cshVrHeadMove>().isSetting = false;
            ovrmyplayer = GameObject.Find("MyPlayer");
            ovrmyplayer.GetComponent<HitJudgment>().WeaponSelect = true;
            Destroy(transform.gameObject);
        }
    }
}
