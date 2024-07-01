using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private GameObject successPrefab;
    [SerializeField] private GameObject failurePrefab;
    [SerializeField] private Transform head;
    [SerializeField] private float scaleChange;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float positionVariance;
    [SerializeField] private float shrinkConstant;
    [SerializeField] private float maxScale;
    [SerializeField] private float minScale;
    protected QuestionManager qm;

    protected virtual void Start()
    {
        qm = FindAnyObjectByType<QuestionManager>();
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
        head.localScale = head.localScale / (scaleChange+0.2f);
        GameObject newbubble = Instantiate(failurePrefab, spawnPoint.position, Quaternion.identity);
        Vector3 changeVector = new Vector3(Random.Range(-positionVariance, positionVariance), Random.Range(-positionVariance, positionVariance), 0);
        newbubble.transform.position += changeVector;
        if (head.transform.localScale.x < minScale)
        {
            head.transform.localScale = new Vector3(minScale, minScale, head.transform.localScale.z);
        }
    }

    private void Update()
    {
        if (qm.PlayerCanRespond())
        {
            head.transform.localScale -= new Vector3(shrinkConstant * Time.deltaTime, shrinkConstant * Time.deltaTime, 0);
        }
        if(head.transform.localScale.x < minScale)
        {
            head.transform.localScale = new Vector3(minScale, minScale, head.transform.localScale.z);
        }
        if (head.transform.localScale.x > maxScale)
        {
            head.transform.localScale = new Vector3(maxScale, maxScale, head.transform.localScale.z);
        }
    }
}
