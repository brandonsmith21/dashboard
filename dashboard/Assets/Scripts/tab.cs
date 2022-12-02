using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tab : MonoBehaviour
{
    public GameObject page;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("tag");

        foreach (GameObject go in gameObjectArray)
        {
            go.SetActive(false);
        }
        GameObject[] tabArray = GameObject.FindGameObjectsWithTag("page");

        foreach (GameObject go in tabArray)
        {
            go.GetComponent<Image>().color = Color.black;
        }

        page.SetActive(true);
        gameObject.GetComponent<Image>().color = GameObject.Find("tabColor").GetComponent<Image>().color;
    }
    public void OnClose()
    {
        if (this.gameObject.name != "tab")
        {
            page.SetActive(false);
            Destroy(this.gameObject);
            GameObject.Find("tab").GetComponent<tab>().OnClick();
        }
    }
}
