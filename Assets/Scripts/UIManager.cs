using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text textValue;
    private string valueFormat;
    float count;


    private void Start()
    {
        valueFormat = textValue.text;
    }

    // Update is called once per frame
    private void Update()
    {
        textValue.text = string.Format(valueFormat,Mathf.CeilToInt(EvaluationManager.Score), EvaluationManager.Combo,EvaluationManager.MaxCombo,
            EvaluationManager.JudgementCounts[JudgementType.Perfect],
            EvaluationManager.JudgementCounts[JudgementType.Good],
            EvaluationManager.JudgementCounts[JudgementType.Bad],
            EvaluationManager.JudgementCounts[JudgementType.Miss]
        );
        //Mathf.CeilToInt(EvaluationManager.Score);
        count += EvaluationManager.JudgementCounts[JudgementType.Perfect];
        ScoreUI.steakCount += Mathf.CeilToInt(count);
    }
}
