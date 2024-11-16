using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using Random = UnityEngine.Random;

public class RoomMover : MonoBehaviour
{
    [SerializeField] List<Transform> positions = new List<Transform>();
    [SerializeField] List<Rigidbody> rooms = new List<Rigidbody>();
    [SerializeField] Rigidbody baseRoom;
    [SerializeField] float speed = 5;
    int roomsCount;

    void Awake()
    { 
        roomsCount = rooms.Count;
        StartCoroutine(Move(baseRoom));
        foreach (var pos in positions)
        {
            int randomNum = Random.Range(0, roomsCount);
            while (rooms[randomNum].gameObject.activeSelf == true)
            {
                randomNum = Random.Range(0, roomsCount);
            }
            rooms[randomNum].transform.position = pos.position;
            rooms[randomNum].gameObject.SetActive(true);
            StartCoroutine(Move(rooms[randomNum]));
        }         
    }

    IEnumerator Move(Rigidbody room)
    {
        while (room.transform.position.y <= 5.8)
        {
            room.velocity = Vector3.up * speed;
            yield return null;
        }
        room.velocity = Vector3.zero;
        room.gameObject.SetActive(false);
        SpawnNewRoom();
    }

    void SpawnNewRoom()
    {
        int randomNum = Random.Range(0, roomsCount);
        while (rooms[randomNum].gameObject.activeSelf == true)
        {
            randomNum = Random.Range(0, roomsCount);
        }
        rooms[randomNum].transform.position = positions[3].position;
        rooms[randomNum].gameObject.SetActive(true);
        StartCoroutine(Move(rooms[randomNum]));
    }
}
