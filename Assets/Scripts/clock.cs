using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clock : MonoBehaviour
{
    [SerializeField] private float maxTime;
    [SerializeField] private Slider slider;

    private float actualTime;
    private bool activeTime;

    private void Start()
    {
        actTimer();
    }
    private void Update()
    {
        if (activeTime)
        {
            changeCounter();
        }
    }

    private void changeCounter()
    {
        actualTime -= Time.deltaTime;

        if(actualTime >= 0)
        {
            slider.value = actualTime;
        }
        if(actualTime <= 0)
        {
            changeCounter();
        }
    }

    private void changeTimer(bool state)
    {
        activeTime = state;
    }

    public void actTimer()
    {
        actualTime = maxTime;
        slider.maxValue = maxTime;
        changeTimer(true);  
    }

    public void desactTimer()
    {
        changeTimer(false);
    }

}
