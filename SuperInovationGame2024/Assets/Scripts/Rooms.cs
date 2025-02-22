using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    [SerializeField] float timerMax;
    [SerializeField] float addSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] RoomGenerator _roomGenerator;
    float timer;
    void Update()
    {
        if (_roomGenerator.Speed >= maxSpeed) return; 
        timer += Time.deltaTime;
        if (timer > timerMax)
        {
            timer = 0;
            _roomGenerator.ChangeSpeed(addSpeed);
        }
    }
}
