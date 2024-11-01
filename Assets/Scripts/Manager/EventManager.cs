using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EventManager : SingletonMono<EventManager>
{
    private Dictionary<string, Delegate> m_EventDictionary;

    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
        m_EventDictionary = new Dictionary<string, Delegate>();
    }

    public void StartListening(TyperEvent nameEvent, Action listener)
    {
        if (m_EventDictionary.TryGetValue(nameEvent.ToString(), out Delegate thisEvent))
        {
            thisEvent = (Action)thisEvent + listener;
            m_EventDictionary[nameEvent.ToString()] = thisEvent;
        }
        else
        {
            m_EventDictionary.Add(nameEvent.ToString(), listener);
        }
    }
    public void StopListening(TyperEvent eventName, Action listener)
    {
        if (m_EventDictionary.TryGetValue(eventName.ToString(), out Delegate thisEvent))
        {
            thisEvent = (Action)thisEvent - listener;
            m_EventDictionary[eventName.ToString()] = thisEvent;
        }
    }
    public void TriggerEvent(TyperEvent eventName)
    {
        if (m_EventDictionary.TryGetValue(eventName.ToString(), out Delegate thisEvent))
        {
            (thisEvent as Action)?.Invoke();
        }
    }
}
public enum TyperEvent
{
    none,
    E_MovingCharacter,
}