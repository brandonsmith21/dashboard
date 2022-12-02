using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dashboard : MonoBehaviour
{
    public GameObject dateRange;
    public GameObject[] tabs;
    public GameObject[] pages;

    public void datePicker(int choice)
    {
        if (choice == 4)
        {
            dateRange.SetActive(true);
        }
        else
        {
            dateRange.SetActive(false);
        }
    }

    public void CreateTab(int i)
    {
        GameObject oldTab = tabs[0];
        GameObject newTab = Instantiate(oldTab);

        newTab.transform.parent = oldTab.transform.parent;
        newTab.GetComponent<tab>().page = pages[i];
        newTab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = pages[i].name;
        newTab.GetComponent<tab>().OnClick();

        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("view");

        foreach (GameObject go in gameObjectArray)
        {
            go.SetActive(false);
        }
    }

    public void CreateView(int i)
    {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("view");

        foreach (GameObject go in gameObjectArray)
        {
            go.SetActive(false);
        }
        pages[i].SetActive(true);
        /*
        GameObject newTab = Instantiate(pages[i]);
        newTab.transform.parent = this.transform.parent;
        newTab.transform.position = pages[i].transform.position;

        newTab.SetActive(true);
        */
    }
}
