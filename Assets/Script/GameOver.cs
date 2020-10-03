using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    GameObject player;
    public static GameObject hpGauge;
    [SerializeField] public  static GameObject canvass;
    //public GameObject hp;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        hpGauge = GameObject.Find("hp_Gauge");
    }
    public static void DecreaseHp()
    {
        hpGauge.GetComponent<Image>().fillAmount -= 0.25f;

    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < -10.6f)
        {
            Debug.Log("gameOver");
            canvass.SetActive(true);
            //コルーチンでゲームオーバー表示してから数秒後にとかの方がいいのかな？
            StartCoroutine("sceneTransition");
            //SceneManager.LoadScene("Stagechoice");
        }
    }


    public static void GameeOver()
    {
//        canvass.SetActive(true);
        SceneManager.LoadScene("Stagechoice");

        //staticじゃないから出来ないとでる。でもstaticにするとアタッチできない
        //texttrue();
    }

    IEnumerator sceneTransition()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Stagechoice");
    }

    public void texttrue()
    {
        Debug.Log("gameOver");
        canvass.SetActive(true);
        //コルーチンでゲームオーバー表示してから数秒後にとかの方がいいのかな？
        StartCoroutine("sceneTransition");
        //SceneManager.LoadScene("Stagechoice");
    }



}
