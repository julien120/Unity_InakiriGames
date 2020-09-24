using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //追加
[RequireComponent(typeof(MoveSceneManager))]
[RequireComponent(typeof(SaveManager))]
[RequireComponent(typeof(SoundManager))]
[DefaultExecutionOrder(-5)]
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [Header("シーンロード時に自動生成するプレハブを登録")]
    [SerializeField]
    GameObject[] prefabs = null;
    //追加
    [Header("UIの設定")]
    [SerializeField]
    GameObject clearCanvasPrefab = null;
    [SerializeField]
    GameObject gameOverCanvasPrefab = null;
    [SerializeField]
    string nextButtonName = "NextButton";
    [SerializeField]
    string retryButtonName = "RetryButton";
    [SerializeField]
    string titleButtonName = "TitleButton";
    MoveSceneManager moveSceneManager;
    SaveManager saveManager;
    SoundManager soundManager;
    //追加
    bool isClear = false;
    bool isGameOver = false;
    int numOfCoins = 0;
    int correctedCoins = 0;
    public int CorrectedCoins
    {
        set
        {
            correctedCoins = value;
            if (correctedCoins >= numOfCoins)
            {
                Clear();
            }
        }
        get
        {
            return correctedCoins;
        }
    }
    protected override void Awake()
    {
        base.Awake();
        if (Debug.isDebugBuild)
        {

        }
        moveSceneManager = GetComponent<MoveSceneManager>();
        saveManager = GetComponent<SaveManager>();
        soundManager = GetComponent<SoundManager>();
    }
    void Start()
    {
        if (Debug.isDebugBuild)
        {
            InstantiateWhenLoadScene();
            InitGame();  //追加
        }
    }
    void Update()
    {

    }
    public void InstantiateWhenLoadScene()
    {
        if (moveSceneManager.SceneName == "Title")
        {
            return;
        }
        foreach (GameObject prefab in prefabs)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
    //--ここから追加--
    //ゲーム初期化メソッド
    public void InitGame()
    {
        isClear = false;
        isGameOver = false;
        numOfCoins = GameObject.FindGameObjectsWithTag("Steak").Length;
        correctedCoins = 0;
    }
    public void Clear()
    {
        if (isClear || isGameOver)
        {
            return;
        }
        isClear = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isActive = false;
        //クリア画面のキャンバスを生成
        Instantiate(clearCanvasPrefab, transform.position, Quaternion.identity);
        //ボタンのコンポーネントを取得
        Button nextButton = GameObject.Find(nextButtonName).GetComponent<Button>();
        Button titleButton = GameObject.Find(titleButtonName).GetComponent<Button>();
        //ボタンに、クリックしたときの処理を登録
        //ただし「次のステージ」ボタンは次のステージがないときは押せないようにする
        if (moveSceneManager.CurrentSceneNum < moveSceneManager.NumOfScene - 1)
        {
            nextButton.onClick.AddListener(() => moveSceneManager.MoveToScene(moveSceneManager.CurrentSceneNum + 1));
        }
        else
        {
            nextButton.interactable = false;
        }
        titleButton.onClick.AddListener(() => moveSceneManager.MoveToScene(0)); //タイトル画面に戻るので、シーン番号は0番
    }
    public void GameOver()
    {
        if (isGameOver || isClear)
        {
            return;
        }
        isGameOver = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isActive = false;
        //ゲームオーバー画面のキャンバスを生成
        Instantiate(gameOverCanvasPrefab, transform.position, Quaternion.identity);
        //ボタンのコンポーネントを取得
        Button retryButton = GameObject.Find(retryButtonName).GetComponent<Button>();
        Button titleButton = GameObject.Find(titleButtonName).GetComponent<Button>();
        //ボタンに、クリックしたときの処理を登録
        retryButton.onClick.AddListener(() => moveSceneManager.MoveToScene(moveSceneManager.CurrentSceneNum));  //リトライなので、今と同じシーンを再読み込み
        titleButton.onClick.AddListener(() => moveSceneManager.MoveToScene(0));  //タイトル画面に戻るので、シーン番号は0番
    }
}