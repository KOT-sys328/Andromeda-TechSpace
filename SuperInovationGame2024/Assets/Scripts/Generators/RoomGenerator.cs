using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    [SerializeField] public List<Material> roomMaterials = new List<Material>();
    [SerializeField] List<Transform> roomsRbs = new List<Transform>();
    [SerializeField] List<Transform> roomsPos = new List<Transform>();
    [SerializeField] Transform firstRoom;
    [SerializeField] float speed = 1;
    public float Speed => speed;
    private int roomsCount;
    private Action<Transform> roomGen;

    void Awake()
    {
        roomGen = (pos) => GenerateRoom(pos);
        firstRoom.gameObject.SetActive(true);
        StartCoroutine(Move(firstRoom));
        roomsCount = roomsRbs.Count;
        foreach (var pos in roomsPos) { roomGen(pos); }
    }
    private void GenerateRoom(Transform pos) {

        int randomNumber = UnityEngine.Random.Range(0, roomsCount);
        while (roomsRbs[randomNumber].gameObject.activeSelf == true) 
        {
            randomNumber = UnityEngine.Random.Range(0, roomsCount);
        }

        roomsRbs[randomNumber].transform.position = pos.position;
        roomsRbs[randomNumber].gameObject.SetActive(true);

        StartCoroutine(Move(roomsRbs[randomNumber]));
    }
    IEnumerator Move(Transform room) 
    {
        while (room.transform.position.y < 7)
        {
            room.position += Vector3.up * speed * Time.deltaTime;
            yield return null;
        }

        room.gameObject.SetActive(false);
        roomGen(roomsPos[roomsPos.Count-1]);
    }
    public void ChangeSpeed(float add_speed)
    {
        speed += add_speed;
    }
}
