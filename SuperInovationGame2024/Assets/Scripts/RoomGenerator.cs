using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{

    [SerializeField] List<Rigidbody> roomsRbs = new List<Rigidbody>();
    [SerializeField] List<Transform> roomsPos = new List<Transform>();
    [SerializeField] Rigidbody firstRoom;
    [SerializeField] float speed;
    private int roomsCount;
    private Action<Transform> roomGen;

    void Awake()
    {
        roomGen = (pos) => GenerateRoom(pos);
        firstRoom.gameObject.SetActive(true);
        StartCoroutine(Move(firstRoom));
        roomsCount = roomsRbs.Count;
        foreach (var pos in roomsPos)
        {
            roomGen(pos);
        }
    }
    private void GenerateRoom(Transform pos)
    {
        int randomNumber = UnityEngine.Random.Range(0, roomsCount);
        while (roomsRbs[randomNumber].gameObject.activeSelf == true)
        {
            randomNumber = UnityEngine.Random.Range(0, roomsCount);
        }

        roomsRbs[randomNumber].transform.position = pos.position;
        roomsRbs[randomNumber].gameObject.SetActive(true);
        StartCoroutine(Move(roomsRbs[randomNumber]));
    }
    IEnumerator Move(Rigidbody room)
    {
        while (room.transform.position.y <= 6)
        {
            room.velocity = Vector3.up * speed;
            yield return null;
        }
        room.velocity = Vector3.zero;
        room.gameObject.SetActive(false);
        roomGen(roomsPos[4]);
    }
}
