using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardStageScript : MonoBehaviour
{
    public GameObject clearCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            clearCanvas.SetActive(true);
            StartCoroutine("clear");
        }
    }

    IEnumerator clear()
    {

        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("StageChoice");


    }
}
