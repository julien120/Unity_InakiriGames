using System.Collections;
using System.Collections.Generic; //Listを使うために必要
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerControllers : MonoBehaviour
{
    //インスペクター上に表示されないのでpublic化した
    [SerializeField] private GameObject prefabSingleNote; //生成するprefab
    [SerializeField] private GameObject prefabLongNote; //生成するprefab
    [SerializeField] AudioSource audioSource; // 音源再生用AudioSource
    //public GameObject prefabSingleNote; //生成するprefab

    public static float ScrollSpeed = 1.0f; //譜面のスクロール速度
    public static float CurrentSec = 0f; //現在の経過時間
    public static float CurrentBeat = 0f; //現在の経過時間(beat)
    // まだ判定処理で消えていないノーツ一覧
    public static List<NoteControllerBase> ExistingNoteControllers;

    public static Beatmap beatmap; // 譜面データを管理する
    private float startOffset = 1.0f; //譜面のオフセット(秒)
    private float startSec = 0f; // 譜面再生開始秒数(再生停止用)
    private bool isPlaying = false; // 譜面停止中か否か

    void Awake()
    {
        //値を初期化
        CurrentSec = 0f;
        CurrentBeat = 0f;

        // 未処理ノーツ一覧を初期化
        ExistingNoteControllers = new List<NoteControllerBase>();

        //TODO: ここで譜面の読み込みを行う
        var beatmapDirectory = Application.streamingAssetsPath+ "/Beatmaps";
        beatmap = new Beatmap(beatmapDirectory + "/sample3.bms");
       

        //デバック用にテンポ変化をコンソールに出力
        foreach (var tempoChange in beatmap.tempoChanges)
        {
            Debug.Log(tempoChange.beat + ": " + tempoChange.tempo);
        }

        //Beatmapクラスのインスタンスを生成
        //beatmap = new Beatmap();

        //ノーツは位置情報を設定
        //beatmap.noteProperties = new List<NoteProperty>
        //{
        //    new NoteProperty(0,0,0, NoteType.Single),
        //    new NoteProperty(1,1,1,NoteType.Single),
        //    new NoteProperty(2,3,2,NoteType.Long),
        //    new NoteProperty(3,4,1,NoteType.Long),
        //    new NoteProperty(4,8,0,NoteType.Long),
        //    new NoteProperty(4,5,4,NoteType.Long),
        //    new NoteProperty(5,6,3,NoteType.Long),
        //    new NoteProperty(6,7,2,NoteType.Single),
        //    new NoteProperty(7,8,3,NoteType.Single),
        //    new NoteProperty(8,9,4,NoteType.Single)
        //};

        ////テンポ変化を設定
        //beatmap.tempoChanges = new List<TempoChange>
        //{
        //    new TempoChange(0,60f),
        //    new TempoChange(2,120f),
        //    new TempoChange(4,60f),
        //    new TempoChange(6,120f)
        //};

        //ここでノーツの生成を行う
        foreach (var noteProperty in beatmap.noteProperties)
        {
            //beatmapのnotepropertiesの各要素の常歩からGameObjectを生成する
            GameObject objNote = null;
            switch (noteProperty.noteType)
            {
                case NoteType.Single:
                    objNote = Instantiate(prefabSingleNote);
                    break;
                case NoteType.Long:
                    objNote = Instantiate(prefabLongNote);
                    break;
            }
            //ノーツ生成時に未処理ノーツ一覧に追加
            ExistingNoteControllers.Add(objNote.GetComponent<NoteControllerBase>());
            objNote.GetComponent<NoteControllerBase>().noteProperty = noteProperty;
        }
        //音源読み込み
        StartCoroutine(LoadAudioFile(beatmap.audioFilePath));
    }

    void Update()
    {
        // 譜面停止中にスペースを押したとき
        if (!isPlaying&&Input.GetKeyDown(KeyCode.Space))
        {
            
            //：コメントアウトした譜面再生
            isPlaying = true;
            // 指定した秒数待って音源再生
            audioSource.PlayScheduled(
                AudioSettings.dspTime + startOffset + beatmap.audioOffset
                );
        }
        //譜面停止中
        if (!isPlaying)
        {
            
            //以下二行を追加した急遽
            // isPlaying = true;
            //audioSource.PlayScheduled(
            //   AudioSettings.dspTime + startOffset + beatmap.audioOffset
            //   );
            //TODO一時停止機能を設けるなら下のコメントアウト消すstartSecを更新し続ける
            startSec = Time.time;
            Debug.Log("譜面停止中");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("StageChoice");
        }



        //秒数を更新
        CurrentSec = Time.time - startOffset - startSec;
        //拍を更新(ToBeatを使用)
        CurrentBeat = Beatmap.ToBeat(CurrentSec, beatmap.tempoChanges);
    }
    // 指定されたパスに存在する音源を読み込む
    private IEnumerator LoadAudioFile(string filePath)
    {
        // ファイルが存在しなければ処理を行わない
        if (!File.Exists(filePath)) { yield break; }
        // 音源のフォーマット種別
        var audioType = GetAudioType(filePath);
        // UnityWebRequestを用いて外部リソースを読み込む
        using (var request = UnityWebRequestMultimedia.GetAudioClip(
            "file:///" + filePath, audioType
            ))
        {
            yield return request.SendWebRequest();
            // エラーが発生しなかった場合
            if (!request.isNetworkError)
            {
                // オーディオクリップを読み込み
                var audioClip = DownloadHandlerAudioClip.GetContent(request);
                // audioSourceのclipに設定
                audioSource.clip = audioClip;
                Debug.Log("音楽を読み込んでる");
            }
        }
    }
    //ファイル名から音源のファイルを取得する
    private AudioType GetAudioType(string filePath)
    {
        //拡張子を取得
        string ext = Path.GetExtension(filePath).ToLower();
        switch (ext)
        {
            case ".ogg":
                return AudioType.OGGVORBIS;
            case ".mp3":
                return AudioType.MPEG;
            case ".wav":
                return AudioType.WAV;
            default:
                return AudioType.UNKNOWN;
        }
    }


}
