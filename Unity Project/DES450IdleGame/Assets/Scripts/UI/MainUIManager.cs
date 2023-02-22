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
    public GameObject CoralLockPanel;
    public GameObject KelpLockPanel;

    public bool CoralLock = true;
    public bool KelpLock = true;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<AudioManager>() != null)
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMainUI()
    {
        LeftPanel.SetActive(true);
        CloseButton.SetActive(true);

        OpenButton.SetActive(false);

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
        CursorPanel.SetActive(true);
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
        OpenButton.SetActive(true);

        LeftPanel.SetActive(false);
        CloseButton.SetActive(false);

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
        SeagrassPanel.SetActive(true);

        CoralPanel.SetActive(false);
        KelpPanel.SetActive(false);
        KelpLockPanel.SetActive(false);
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
        CoralPanel.SetActive(false);
        CoralLockPanel.SetActive(false);

        audioManager.UIClicked();
    }
}
