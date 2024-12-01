using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public void StartListening<T>(TyperEvent eventName, Action<T> listener)
    {
        if (m_EventDictionary.TryGetValue(eventName.ToString(), out Delegate thisEvent))
        {
            thisEvent = (Action<T>)thisEvent + listener;
            m_EventDictionary[eventName.ToString()] = thisEvent;
        }
        else
        {
            m_EventDictionary.Add(eventName.ToString(), listener);
        }
    }

    public void StopListening<T>(TyperEvent eventName, Action<T> listener)
    {
        if (m_EventDictionary.TryGetValue(eventName.ToString(), out Delegate thisEvent))
        {
            thisEvent = (Action<T>)thisEvent - listener;
            m_EventDictionary[eventName.ToString()] = thisEvent;
        }
    }

    public void TriggerEvent<T>(TyperEvent eventName, T param)
    {
        if (m_EventDictionary.TryGetValue(eventName.ToString(), out Delegate thisEvent))
        {
            (thisEvent as Action<T>)?.Invoke(param);
        }
    }

    public void StartListening<T1, T2>(TyperEvent eventName, Action<T1, T2> listener)
    {
        if (m_EventDictionary.TryGetValue(eventName.ToString(), out Delegate thisEvent))
        {
            thisEvent = (Action<T1, T2>)thisEvent + listener;
            m_EventDictionary[eventName.ToString()] = thisEvent;
        }
        else
        {
            m_EventDictionary.Add(eventName.ToString(), listener);
        }
    }

    public void StopListening<T1, T2>(TyperEvent eventName, Action<T1, T2> listener)
    {
        if (m_EventDictionary.TryGetValue(eventName.ToString(), out Delegate thisEvent))
        {
            thisEvent = (Action<T1, T2>)thisEvent - listener;
            m_EventDictionary[eventName.ToString()] = thisEvent;
        }
    }

    public void TriggerEvent<T1, T2>(TyperEvent eventName, T1 param1, T2 param2)
    {
        if (m_EventDictionary.TryGetValue(eventName.ToString(), out Delegate thisEvent))
        {
            (thisEvent as Action<T1, T2>)?.Invoke(param1, param2);
        }
    }
}
public enum TyperEvent
{
    none, 
    ResetAllSubBlock,
}