using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishManager : MonoBehaviour {

    #region singleton
    private static FinishManager instance;
    public static FinishManager Get()
    {
        return instance;
    }
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
    #endregion
    public delegate void FinishActions(FinishManager f);
    public static FinishActions GoalTouched;
    public static FinishActions LevelFinish;

    private int goalCount;

    private void Start()
    {
        goalCount = 4;
        FinishGoal.Finished += GoalTouch;
    }

    private void Update()
    {
        if (goalCount <= 0)
        {
            goalCount = 5;
            LevelFinish(this);
        }
    }
    private void GoalTouch(FinishGoal f)
    {
        GoalTouched(this);
        goalCount--;
    }
}
