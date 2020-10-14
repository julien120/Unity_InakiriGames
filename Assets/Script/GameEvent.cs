using System.Collections;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditorInternal;
using UnityEditor;
#endif

public class GameEvent : MonoBehaviour
{
    public bool BattleTransition = false;
    BaseCharacterController bcs;

    [Tooltip("イベント開始時の処理")]
    [SerializeField] UnityEvent startEvent;

    [Tooltip("イベント終了時の処理")]
    [SerializeField] UnityEvent endEvent;

    [Tooltip("Fire1で進むイベント")]
    [HideInInspector] public UnityEvent[] events;

    public void Play()
    {
        //bcs.isActive = false;
        StartCoroutine(Progress());
    }

    IEnumerator Progress()
    {
        startEvent.Invoke();
        
        foreach( var ev in events)
        {
            ev.Invoke();
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            //yield return new WaitUntil(()=> Input.GetButtonDown("Fire1"));
            yield return null;
        }

        endEvent.Invoke();
    }
}

#if UNITY_EDITOR

[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor
{
    private ReorderableList reorderableList;
    private SerializedProperty selectedProperty = null;

    private bool isStartEnd = false;

    void OnEnable()
    {
        var property = serializedObject.FindProperty("events");
        reorderableList = new ReorderableList(serializedObject, property);

        reorderableList.onSelectCallback  = (reorderableList)=>{
            selectedProperty = property.GetArrayElementAtIndex(reorderableList.index);
        };
        reorderableList.drawHeaderCallback += (rect)=>{ EditorGUI.LabelField(rect, "Event");};
    }

    public override void OnInspectorGUI()
    {
        isStartEnd = EditorGUILayout.Foldout(isStartEnd, "Callback");
        if( isStartEnd )
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("startEvent"));
            
            EditorGUILayout.PropertyField(serializedObject.FindProperty("endEvent"));

        }

        reorderableList.DoLayoutList();

        if( selectedProperty != null)
            EditorGUILayout.PropertyField(selectedProperty);

        if( GUI.changed)
        {
            Undo.RecordObject(target, "change value");
            serializedObject.ApplyModifiedProperties();
        }
    }

}

#endif