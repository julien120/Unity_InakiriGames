using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SteakItem : MonoBehaviour
{
    //float steakCount;
    //public Text steakUI;
    public GameObject steak;
    public GameObject UI;
    ScoreUI scoreUI;

    // Start is called before the first frame update
    void Start()
    {
        //cs型変数名 = GameObject型変数名.GetComponent<cs名>();
        scoreUI = UI.GetComponent<ScoreUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            scoreUI.steakCount += 300;
            //gameObject.SendMessage("count", 300,SendMessageOptions.DontRequireReceiver);
            //steakCount += 300;
            //Debug.Log(steakCount);

            //steakUI.text = "肉マイレージ数：" + steakCount.ToString("f0") + "g";

            //steak.SetActive(false);
            Destroy(steak);

        }


    }
}
