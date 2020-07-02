using Microsoft.MixedReality.Toolkit.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MrPP { 
    public class HandButton : MonoBehaviour, IMixedRealityTouchHandler
    {
        public FollowTrackedFingers _follow;
        public float _display = 0.05f;
        public UnityEvent _onTigger;
        public void Update() {
            if (_follow.wristObjectL.activeSelf)
            {
                if (Vector3.Distance(this.transform.position, _follow.wristObjectL.transform.position) < _display)
                {
                    tigger();
                }
            }
            else if (_follow.wristObjectR.activeSelf)
            {
                if (Vector3.Distance(this.transform.position, _follow.wristObjectR.transform.position) < _display)
                {
                    tigger();
                }
            }
        }

        private void tigger()
        {
            _onTigger?.Invoke();
        }

        public void OnTouchCompleted(HandTrackingInputEventData eventData)
        {
            Debug.Log("OnTouchCompleted");
        }
        private void OnTriggerEnter(Collider collision) {
            Debug.LogError("!"+collision.GetComponent<Collider>().gameObject.name);
        }
        private void OnCollisionEnter(Collision collision)
        {
           
                Debug.LogError(collision.collider.gameObject.name);
            
        }
        public void OnTouchStarted(HandTrackingInputEventData eventData)
        {
            Debug.Log("OnTouchStarted1!!!!");
        }

        public void OnTouchUpdated(HandTrackingInputEventData eventData)
        {
            Debug.Log("OnTouchUpdated");
        }

      
    }
}