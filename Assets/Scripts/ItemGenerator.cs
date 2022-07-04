using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject[] itemPrefabs;

    [SerializeField] Transform plateBox;

    public float num = 3f;

    private void Spawn()
    {
        GameObject plate = Instantiate(itemPrefabs[0], transform.position, transform.rotation);
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
        float num = GameManager.Instance.mainGameSpeed;
        StartCoroutine("Generat");
    }

    void Update() { }
}
