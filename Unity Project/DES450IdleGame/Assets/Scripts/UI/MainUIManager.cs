using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    public GameObject LeftPanel;
    public GameObject MonsterPanel;
    public GameObject SkillTreePanel;
    public GameObject CursorPanel;
    public GameObject BoatsPanel;
    public GameObject FloraPanel;
    public GameObject OpenButton;
    public GameObject CloseButton;
    public GameObject SeagrassPanel;
    public GameObject CoralPanel;
    public GameObject KelpPanel;
    public GameObject SeagrassLockPanel;
    public GameObject CoralLockPanel;
    public GameObject KelpLockPanel;
    public GameObject OffScreenObject;

    public float InAndOutSpeed = 0.03f;

    public bool MainUI_Active = true;

    public bool SeagrassLock = true;
    public bool CoralLock = true;
    public bool KelpLock = true;

    private AudioManager audioManager;

    private float timer = 0f;
    private float origX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<AudioManager>() != null)
        {
            audioManager = FindObjectOfType<AudioManager>();
        }

        //original X position of main UI
        origX = LeftPanel.GetComponent<RectTransform>().position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(LeftPanel.GetComponent<RectTransform>().position.x);

        //Lerp To Default Location
        if (MainUI_Active == true)
        {
            timer += Time.deltaTime;
            float posX = Mathf.Lerp(OffScreenObject.transform.position.x, origX, timer * InAndOutSpeed);

            LeftPanel.GetComponent<RectTransform>().position = new Vector3(posX, LeftPanel.GetComponent<RectTransform>().position.y, LeftPanel.GetComponent<RectTransform>().position.z);
        }

        //Lerp Off Screen
        if (MainUI_Active == false)
        {
            timer += Time.deltaTime;
            float posX = Mathf.Lerp(origX, OffScreenObject.transform.position.x, timer * InAndOutSpeed);

            LeftPanel.GetComponent<RectTransform>().position = new Vector3(posX, LeftPanel.GetComponent<RectTransform>().position.y, LeftPanel.GetComponent<RectTransform>().position.z);

            if (LeftPanel.GetComponent<RectTransform>().position.x >= OffScreenObject.transform.position.x - 0.05f && LeftPanel.GetComponent<RectTransform>().position.x <= origX + 0.05f)
            {
                OpenButton.SetActive(true);
            }
        }
    }

    public void OpenMainUI()
    {
        //LeftPanel.SetActive(true);
        //CloseButton.SetActive(true);

        OpenButton.SetActive(false);

        timer = 0f;

        MainUI_Active = true;

        audioManager.UIClicked();
    }

    public void OpenMonsterPanel()
    {
        MonsterPanel.SetActive(true);

        CursorPanel.SetActive(false);
        BoatsPanel.SetActive(false);
        FloraPanel.SetActive(false);

        audioManager.UIClicked();
    }

    public void OpenSkillTree()
    {
        SkillTreePanel.SetActive(true);

        LeftPanel.SetActive(false);
        CloseButton.SetActive(false);

        audioManager.UIClicked();
    }

    public void OpenCursorPanel()
    {
        CursorPanel.SetActive(true);

        MonsterPanel.SetActive(false);
        BoatsPanel.SetActive(false);
        FloraPanel.SetActive(false);

        audioManager.UIClicked();
    }

    public void OpenBoatsPanel()
    {
        BoatsPanel.SetActive(true);

        MonsterPanel.SetActive(false);
        CursorPanel.SetActive(false);
        FloraPanel.SetActive(false);

        audioManager.UIClicked();
    }

    public void OpenFloraPanel()
    {
        FloraPanel.SetActive(true);

        MonsterPanel.SetActive(false);
        CursorPanel.SetActive(false);
        BoatsPanel.SetActive(false);

        audioManager.UIClicked();
    }

    public void CloseMainUI()
    {
        //OpenButton.SetActive(true);

        //LeftPanel.SetActive(false);
        //CloseButton.SetActive(false);

        timer = 0f;

        MainUI_Active = false;

        audioManager.UIClicked();
    }

    public void CloseSkillTree()
    {
        LeftPanel.SetActive(true);
        CloseButton.SetActive(true);

        SkillTreePanel.SetActive(false);

        audioManager.UIClicked();
    }

    public void OpenSegrassTab()
    {
        if (SeagrassLock == true)
        {
            SeagrassLockPanel.SetActive(true);
        }
        else
        {
            SeagrassPanel.SetActive(true);
        }

        KelpPanel.SetActive(false);
        KelpLockPanel.SetActive(false);
        CoralPanel.SetActive(false);
        CoralLockPanel.SetActive(false);

        audioManager.UIClicked();
    }

    public void OpenCoralTab()
    {
        if (CoralLock == true)
        {
            CoralLockPanel.SetActive(true);
        }
        else
        {
            CoralPanel.SetActive(true);
        }

        SeagrassPanel.SetActive(false);
        SeagrassLockPanel.SetActive(false);
        KelpPanel.SetActive(false);
        KelpLockPanel.SetActive(false);

        audioManager.UIClicked();
    }

    public void OpenKelpTab()
    {
        if (KelpLock == true)
        {
            KelpLockPanel.SetActive(true);
        }
        else
        {
            KelpPanel.SetActive(true);
        }

        SeagrassPanel.SetActive(false);
        SeagrassLockPanel.SetActive(false);
        CoralPanel.SetActive(false);
        CoralLockPanel.SetActive(false);

        audioManager.UIClicked();
    }

    public void UnlockSeagrass()
    {
        SeagrassLock = false;
        SeagrassLockPanel.SetActive(false);
        SeagrassPanel.SetActive(true);
    }

    public void UnlockCoral()
    {
        CoralLock = false;
        CoralLockPanel.SetActive(false);
        CoralPanel.SetActive(true);
    }

    public void UnlockKelp()
    {
        KelpLock = false;
        KelpLockPanel.SetActive(false);
        KelpPanel.SetActive(true);
    }
}
