using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    #region singleton
    private static CameraController instance;
    public static CameraController Get()
    {
        return instance;
    }
    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(this);
    }
    #endregion

    public Camera GetViewport()
    {
        return GetComponent<Camera>();
    }
}
