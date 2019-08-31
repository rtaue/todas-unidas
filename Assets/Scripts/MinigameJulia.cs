using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameJulia : MonoBehaviour
{       
    public GameObject img;
    
    public Button button;


    public GameObject panel2;  //botões do quarto


    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(OpenImage);
        

    }
    
    public void Back()
    {
        
        img.SetActive(false);
     
        panel2.SetActive(true);
    }

    public void OpenImage()
    {

        img.SetActive(true);
      
        panel2.SetActive(false);

    }
}



