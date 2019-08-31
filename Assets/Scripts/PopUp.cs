using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public GameObject popUp;

    float x = 0;

    public Button button;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(OpenPopup);

      
    }

    void Update()
    {
        x += Time.deltaTime;

        if (x >= 4)
        {
            popUp.SetActive(false);
            x = 0;
        }
    }

    void OpenPopup()
    {
       
        popUp.SetActive(true);
                           
    }
}