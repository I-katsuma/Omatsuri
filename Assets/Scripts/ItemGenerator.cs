using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] itemPrefabs; // 生成する景品's

    [SerializeField]
    Transform plateBox; // 生成された景品たちの格納場所

    public float _osaraNum = 3f; // お皿の間隔

    int ranNum; // ランダム数字変数

    int GetRAndomValue(int oldNum)
    {
        int length = itemPrefabs.Length;
        int newNum = Random.Range(0, length);

        if (newNum == oldNum) // 古い番号が同じとき
        {
            int n = newNum + Random.Range(1, length);

            return n < length ? n : n - length;
        }
        else
        {
            return newNum;
        }
    }

    private void Spawn()
    {
        //ranNum = Random.Range(0, itemPrefabs.Length);
        ranNum = GetRAndomValue(ranNum);

        if (GameManager.Instance.GoldCatFlag || GameManager.Instance.GetGoldCat)
        {
            Debug.Log("実行");
            ranNum = Random.Range(1, itemPrefabs.Length);
        }
        
        GameObject plate = Instantiate(itemPrefabs[ranNum], transform.position, transform.rotation);
        plate.transform.SetParent(plateBox);
    }

    IEnumerator Generat()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(_osaraNum);
        }
    }

    void Start()
    {
        //float num = GameManager.Instance.mainGameSpeed;
        GameManager.Instance.GoldCatFlag = false;
        StartCoroutine("Generat");
    }
}
