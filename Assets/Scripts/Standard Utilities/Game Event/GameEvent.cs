using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StandardUtilities.Events
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();

#if UNITY_EDITOR
        [Multiline]
        public string developerDescription;
#endif

        public void Subscribe(GameEventListener listener)
        {
            listeners.Add(listener);
        }

        public void Unsubscribe(GameEventListener listener)
        {
            listeners.Remove(listener);
        }

        public void Trigger(object payload)
        {
            for(int i = 0; i < listeners.Count; i++)
            {
                listeners[i].onEventTriggered.Invoke();
                listeners[i].onEventTriggeredWithPayload.Invoke(payload);
            }
        }
    }
}