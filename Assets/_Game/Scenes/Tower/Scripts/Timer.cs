using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionTimer
{
    private static List<FunctionTimer> activeTimerList;
    private static GameObject initGameObject;
    private static void InitIfNeeded()
    {
        if(initGameObject == null){
            initGameObject = new GameObject("FunctionTimer_InitGameObject");
            activeTimerList = new List<FunctionTimer>();
        }
    }
    public static FunctionTimer Create(float timer, Action action, string timerName = null){
        InitIfNeeded();

        GameObject gameObject = new GameObject("FunctionTimer", typeof(MonoBehaviourHook));
        FunctionTimer functionTimer = new FunctionTimer(timer, action, timerName, gameObject);
        
        gameObject.GetComponent<MonoBehaviourHook>().onUpdate = functionTimer.Update;

        activeTimerList.Add(functionTimer);

        return functionTimer;
    }

    private static void RemoveTimer(FunctionTimer functionTimer)
    {
        InitIfNeeded();
        activeTimerList.Remove(functionTimer);
    }

    private static void StopTimer(string timerName)
    {
        for(int i=0; i<activeTimerList.Count; i++){
            if(activeTimerList[i].timerName == timerName){
                activeTimerList[i].DestroySelf();
                i--;
            }
        }
    }

    public class MonoBehaviourHook : MonoBehaviour {
        public Action onUpdate;
        private void Update() {
            if(onUpdate != null) onUpdate();
        }
    }

    private Action timerCallback;
    private float timer;
    private bool isDestroyed;
    private GameObject gameObject;
    private string timerName;

    private FunctionTimer(float timer, Action timerCallback, string timerName, GameObject gameObject)
    {
        this.timer = timer;
        this.timerCallback = timerCallback;
        this.timerName = timerName;
        this.gameObject = gameObject;
    }

    public void Update() {
        if(timer > 0f){
            timer -= Time.deltaTime;

            if(IsTimerComplete()){
                timerCallback();
                DestroySelf();
            }
        }
    }

    private void DestroySelf()
    {
        isDestroyed = true;
        UnityEngine.Object.Destroy(gameObject);
        RemoveTimer(this);
    }

    public bool IsTimerComplete()
    {
        return timer <= 0f;
    }
}
