using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskDisplay : MonoBehaviour
{
    private const string DEFAULT_TEXT = "Return";

    [SerializeField] private GameObject _textPrefab;

    private List<GameObject> _taskObjects = new List<GameObject>();

    private void Start()
    {
        SetTasks();
    }

    private void SetTasks()
    {
        for (int i = 0; i < TaskHandler.Tasks.Count; i++)
        {
            GameObject textObject = Instantiate(_textPrefab, transform);
            TextMeshProUGUI textComponent = textObject.GetComponent<TextMeshProUGUI>();
            textComponent.text = DEFAULT_TEXT + " " + TaskHandler.Tasks[i].Item.Name;
            _taskObjects.Add(textObject);
        }
    }

    private void OnEnable()
    {
        TaskHandler.TaskCompleted += TaskUpdate;
    }

    private void OnDisable()
    {
        TaskHandler.TaskCompleted -= TaskUpdate;
    }

    private void TaskUpdate()
    {
        ClearTasks();
        SetTasks();
    }

    private void ClearTasks()
    {
        for(int i = 0; i < _taskObjects.Count; i++)
        {
            Destroy(_taskObjects[i]);
            _taskObjects.Remove(_taskObjects[i]);
        }
    }
}
