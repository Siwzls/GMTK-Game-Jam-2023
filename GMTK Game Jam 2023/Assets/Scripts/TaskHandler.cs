using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskHandler : MonoBehaviour
{
    [SerializeField] private ItemSpawner _itemSpawner;

    private static List<Task> _tasks = new List<Task>();
    private static ReturnSpot[] _returnSpots;

    public static Action AllTasksCompleted;
    public static Action TaskCompleted;

    public static List<Task> Tasks => _tasks;

    private void Start()
    {
        _returnSpots = FindReturnSpots();
        CreateTasks();
        foreach(ReturnSpot returnSpot in _returnSpots)
        {
            returnSpot.ItemReturned += OnItemReturning;
        }
    }

    private void OnDisable()
    {
        if (_returnSpots != null)
        {
            foreach (ReturnSpot retrunSpot in _returnSpots)
            {
                retrunSpot.ItemReturned -= OnItemReturning;
            }
        }
    }

    private ReturnSpot[] FindReturnSpots()
    {
        return FindObjectsOfType<ReturnSpot>();
    }

    private void CreateTasks()
    {
        for(int i = 0; i < _returnSpots.Length; i++)
        {
            Task task = new Task(_returnSpots[i].ItemToReturn);
            _tasks.Add(task);
        }
    }

    private void OnItemReturning(ItemData data)
    {
        Task item = FindTask(data);
        _tasks.Remove(item);
        TaskCompleted?.Invoke();
        CheckTasks();
    }

    private Task FindTask(ItemData item)
    {
        for (int i = 0; i < _tasks.Count; i++)
        {
            if (item == _tasks[i].Item)
            {
                return _tasks[i];
            }
        }
        return null;
    }
    private void CheckTasks()
    {
        if(_tasks.Count <= 0)
        {
            AllTasksCompleted?.Invoke();
        }    
    }
}
