using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    [SerializeField] private Transform image;
    [SerializeField] private float shrinkTime;
    [SerializeField] private float shrinkVariance;
    private float initialScale;
    private float timePassed = 0;
    // Start is called before the first frame update
    void Start()
    {
        initialScale = image.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        float newScale = Mathf.Sin(timePassed / shrinkTime) * shrinkVariance;
        image.localScale = new Vector3(initialScale + newScale, initialScale + newScale, initialScale);
        if(image.localScale.y <= 0.01)
        {
            Destroy(gameObject);
        }
    }
}
