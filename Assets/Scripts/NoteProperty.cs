
public class NoteProperty
{
    public float beatBegin; //始点が判定ラインと重なるbeat
    public float beatEnd; //終点が判定ラインと重なるbeat
    public float secBegin; //始点が判定ラインと重なるsec
    public float secEnd; //終点が判定ラインと重なるsec
    public int lane; //レーン
    public NoteType noteType; //ノーツ種別

    //コンストラクタ
    public NoteProperty(float beatBegin, float beatEnd, int lane, NoteType noteType)
    {
        this.beatBegin = beatBegin;
        this.beatEnd = beatEnd;
        this.lane = lane;
        this.noteType = noteType;
    }


}
//定数をまとめて管理できる列挙型
//定数とは変更できない値でMax_Scoreなど共通の規格を設けるにあたって有効
//いなきりステーキだとstageのボトムランキング、stageChoiceのボトムランキングばらばらだけど
public enum NoteType
{
    Single, //シングルノーツ
    Long //ロングノーツ
}
