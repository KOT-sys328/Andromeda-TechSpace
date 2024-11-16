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

    void Awake()
    {
        firstRoom.gameObject.SetActive(true);
        roomsCount = roomsPos.Count;
        foreach (var pos in roomsPos)
        {
            GenerateRoom(pos);
        }
    }

    private void GenerateRoom(Transform pos)
    {
        int randomNumber = Random.Range(0, roomsCount);
        while (roomsRbs[randomNumber].gameObject.activeSelf == true)
        {
            randomNumber = Random.Range(0, roomsCount);
        }

        roomsRbs[randomNumber].transform.position = pos.position;
        roomsRbs[randomNumber].gameObject.SetActive(true);
        StartCoroutine(Move(roomsRbs[randomNumber]));
    }
    IEnumerator Move(Rigidbody room)
    {
        while (room.transform.position.y <= 4.8)
        {
            room.velocity = Vector3.up * speed;
            yield return null;
        }
        GenerateRoom(roomsPos[roomsCount - 1]);
    }
}
