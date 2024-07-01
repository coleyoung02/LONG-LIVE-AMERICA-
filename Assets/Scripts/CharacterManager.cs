using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] GameObject successPrefab;
    [SerializeField] GameObject failurePrefab;
    [SerializeField] Transform head;
    [SerializeField] float scaleChange;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float positionVariance;
    protected virtual void Start()
    {

    }

    public void OnSuccess(string content)
    {
        head.localScale = head.localScale * scaleChange;
        GameObject newbubble = Instantiate(successPrefab, spawnPoint.position, Quaternion.identity);
        Vector3 changeVector = new Vector3(Random.Range(0, positionVariance), Random.Range(0,positionVariance), 0);
        newbubble.transform.position += changeVector;

    }

    public void OnFail(string content)
    {
        head.localScale = head.localScale / scaleChange;
        GameObject newbubble = Instantiate(failurePrefab, spawnPoint.position, Quaternion.identity);
        Vector3 changeVector = new Vector3(Random.Range(0, positionVariance), Random.Range(0, positionVariance), 0);
        newbubble.transform.position += changeVector;
    }
}
