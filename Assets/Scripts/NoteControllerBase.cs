using UnityEngine;

public abstract class NoteControllerBase : MonoBehaviour
{
    //abstractは抽象クラスで、これを継承した様々なオブジェクトに共通な規格を設けることができる
    public NoteProperty noteProperty;
    public bool isProcessed = false; //ロングノーツ用処理中フラグ

    //キー押した時の処理
    public virtual void OnKeyDown(JudgementType judgementType)
    {

    }

    //キーを話した時の処理
    public virtual void OnKeyUp(JudgementType judgementType) { }
 
}
