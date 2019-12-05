using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace StandardUtilities.Events
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent gameEvent;

        public UnityEvent onEventTriggered;
        public UEP onEventTriggeredWithPayload;

        private void OnEnable()
        {
            gameEvent?.Subscribe(this);
        }

        private void OnDisable()
        {
            gameEvent?.Unsubscribe(this);
        }

        [System.Serializable]
        public class UEP : UnityEvent<object> { }
    }
}