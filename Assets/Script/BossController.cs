using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public bool bossSwich;
    bool ii;
    private bool aa;
    // Start is called before the first frame update
    void Start()
    {
        if (bossSwich == true)
        {
            Debug.Log("コンポーネント削除");
            GameObject BOSS = GameObject.Find("Boss1");
            var bbb = BOSS.GetComponent<GameEvent>();
            Destroy(bbb);
        }else if(bossSwich == false)
        {
            Debug.Log("falseかいな");
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void swich()
    {
        bossSwich = !bossSwich;
    }
}
