using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinGenerator : MonoBehaviour
{

    [SerializeField] List<Transform> coinTrn = new List<Transform>();
    [SerializeField] List<GameObject> coinGmo = new List<GameObject>();
    [SerializeField] float speed;
    private int coinRandom;
    private float coinTimer;
    private float coinNextTimer = 3;
    private new List<GameObject> coinslist = new List<GameObject>();
   
    private Action<Transform> roomGen;

    void Awake()
    {
        roomGen = (pos) => GenerateCoin();
    }
    private void Update()
    {
        GenerateCoin();
    }
    private void GenerateCoin() {
        coinTimer += Time.deltaTime;
        if (coinTimer >= coinNextTimer)
        {
            coinRandom = Random.Range(0, 20);
            if (coinRandom <= 14) {
                var coin = Instantiate(coinGmo[0], new Vector3(Random.Range(-3, 3), -6, Random.Range(-3, 3)), new Quaternion(0, 0, 0, 0));
                StartCoroutine(Move(coin));
            }
            if (coinRandom >= 15 && coinRandom <= 19) {
                var coin = Instantiate(coinGmo[1], new Vector3(Random.Range(-3, 3), -6, Random.Range(-3, 3)), new Quaternion(0, 0, 0, 0));
                StartCoroutine(Move(coin));
            }
            else {
                var coin = Instantiate(coinGmo[2], new Vector3(Random.Range(-3, 3), -6, Random.Range(-3, 3)), new Quaternion(0, 0, 0, 0));
                StartCoroutine(Move(coin));
            }
            coinTimer = 0;
            coinNextTimer = Random.Range(1, 8);
        }
    }
    IEnumerator Move(GameObject coin) {
        while (coin.transform.position.y < 6) {
            coin.transform.position += Vector3.up * speed * Time.deltaTime;
            yield return null;
        }
        coin.gameObject.SetActive(false);
    }

}
