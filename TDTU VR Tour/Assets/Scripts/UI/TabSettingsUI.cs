using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabSettingsUI : MonoBehaviour
{
    public List<GameObject> tabButtons;
    public List<GameObject> tabContents;
    public void HideAllTabs()
    {
        foreach (var tab in tabContents)
        {
            tab.SetActive(false);
        }
        // Change color
        foreach (var button in tabButtons)
        {
            button.GetComponent<Button>().image.color = new Color32(212, 212, 212, 255);
            Debug.Log("Color changed");    
        }
        
    }

    public void ShowTab(int tab)
    {
        if (tab < 0 || tab >= tabContents.Count)
        {
            Debug.LogError("Invalid tab");
            return;
        }

        HideAllTabs();
        tabContents[tab].SetActive(true);
        // Change color
        tabButtons[tab].GetComponent<Button>().image.color = new Color32(255, 255, 255, 255);
        Debug.Log("Color changed");
    }
}