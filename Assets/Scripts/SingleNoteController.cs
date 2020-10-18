using UnityEngine;

public class SingleNoteController : NoteControllerBase
{
    [SerializeField] AudioClip clipHit; // 効果音

    void Update()
    {
        SetTransform();
        CheckMiss();
    }

    //ノーツの座標設定
    private void SetTransform()
    {
        //ノーツの座標
        Vector2 position = new Vector2();
        position.x = noteProperty.lane - 2;
        position.y = (noteProperty.beatBegin - PlayerControllers.CurrentBeat) * PlayerControllers.ScrollSpeed;
        transform.localPosition = position;
    }

    //見逃し検出
    private void CheckMiss()
    {
        //判定ラインを通過した後、BADの判定幅よりも離れるとノーツを削除
        if(noteProperty.secBegin - PlayerControllers.CurrentSec< -JudgementManager.JudgementWidth[JudgementType.Bad])
        {
            //TODOミス処理
            EvaluationManager.OnMiss();

            //未処理ノーツ一覧から削除
            PlayerControllers.ExistingNoteControllers.Remove(
                GetComponent<NoteControllerBase>()
                );
            //GameObject自体も削除
            Destroy(gameObject);
        }
    }


    //キーが押されたとき
    public override void OnKeyDown(JudgementType judgementType)
    {
        //デバックようにコンソールに判定を出力
        Debug.Log(judgementType);

        //判定がMiss出ない時(Bad以内のとき)
        if(judgementType != JudgementType.Miss)
        {
            //TODOヒット処理(スコア・コンボ数などを変更)
            EvaluationManager.OnHit(judgementType);

            //　効果音再生
            AudioSource.PlayClipAtPoint(clipHit, transform.position);
            //未処理ノーツ一覧から削除
            PlayerControllers.ExistingNoteControllers.Remove(
                GetComponent<NoteControllerBase>()
                );
            // GameObject自体も削除
            Destroy(gameObject);
        }
    }


}
