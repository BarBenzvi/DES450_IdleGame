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

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    public void OpenMonsterPanel()
    {
        MonsterPanel.SetActive(true);

        CursorPanel.SetActive(false);
        BoatsPanel.SetActive(false);
        FloraPanel.SetActive(false);
    }

    public void OpenSkillTree()
    {
        SkillTreePanel.SetActive(true);

        LeftPanel.SetActive(false);
        CloseButton.SetActive(false);
    }

    public void OpenCursorPanel()
    {
        CursorPanel.SetActive(true);

        MonsterPanel.SetActive(false);
        BoatsPanel.SetActive(false);
        FloraPanel.SetActive(false);
    }

    public void OpenBoatsPanel()
    {
        BoatsPanel.SetActive(true);

        MonsterPanel.SetActive(false);
        CursorPanel.SetActive(true);
        FloraPanel.SetActive(false);
    }

    public void OpenFloraPanel()
    {
        FloraPanel.SetActive(true);

        MonsterPanel.SetActive(false);
        CursorPanel.SetActive(false);
        BoatsPanel.SetActive(false);
    }

    public void CloseMainUI()
    {
        OpenButton.SetActive(true);

        LeftPanel.SetActive(false);
        CloseButton.SetActive(false);
    }

    public void CloseSkillTree()
    {
        LeftPanel.SetActive(true);
        CloseButton.SetActive(true);

        SkillTreePanel.SetActive(false);
    }
}
