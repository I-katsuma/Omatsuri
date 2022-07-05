using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] itemPrefabs;

    [SerializeField] Transform plateBox;

    public float num = 3f; // お皿の間隔

    int ranNum;
    //int preNum = -1;

    int GetRAndomValue(int oldNum)
    {
        int length = itemPrefabs.Length;
        int newNum = Random.Range(0, length);

        if(newNum == oldNum) // 古い番号が同じとき
        {
            int n = newNum + Random.Range(1, length);

            return n < length ? n : n -length;
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

        GameObject plate = Instantiate(itemPrefabs[ranNum], transform.position, transform.rotation);
        plate.transform.SetParent(plateBox);
    }

    IEnumerator Generat()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(num);
        }
    }

    void Start()
    {
        //float num = GameManager.Instance.mainGameSpeed;
        StartCoroutine("Generat");
    }

}
