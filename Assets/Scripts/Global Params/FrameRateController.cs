using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateController : MonoBehaviour
{
    [SerializeField] int _frameRate;
    private void OnValidate()
    {
        Application.targetFrameRate = _frameRate;

    }
}
