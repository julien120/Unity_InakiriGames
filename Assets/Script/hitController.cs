using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hitController : MonoBehaviour
{
    //public GameObject canvas;
    public void shoot(Vector3 dir)
    {
        StartCoroutine("destroy");
        GetComponent<Rigidbody2D>().AddForce(dir);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        GetComponent<Rigidbody2D>().isKinematic = true;

        if (coll.gameObject.CompareTag("steakSushi"))
        {
            StartCoroutine("hit");
            ScoreUI.steakCount += 300;
            
        }

        if (coll.gameObject.CompareTag("sushi"))
        {
            Destroy(gameObject);
            ScoreUI.steakCount -= 300;
            GameOver.DecreaseHp();
            StartCoroutine("hit");


        }

        if (coll.gameObject.CompareTag("hitDestroy"))
        {
            Destroy(gameObject);
            Debug.Log("画面外に出たので消滅");
        }


    }
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator hit()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(6.5f);
        Destroy(gameObject);
    }
}
