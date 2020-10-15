using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSceneController : MonoBehaviour
{
    public GameObject modalWindow;
    bool swich = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void userGuide()
    {
        if (swich==false) {
        this.modalWindow.SetActive(true);
            swich = true;
        }else if(swich == true)
        {
            this.modalWindow.SetActive(false);
            swich = false;
        }
    }

    public void stage1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void stage2()
    {
        SceneManager.LoadScene("stage2");
    }

    public void stage3()
    {
        SceneManager.LoadScene("stage3");
    }
    public void stage4()
    {
        SceneManager.LoadScene("stage4");
    }
}
