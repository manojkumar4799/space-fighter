using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceback : MonoBehaviour
{
    [SerializeField] float backgroundSpeed = 0.6f;
    Material mymaterial;
    Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        mymaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0f, backgroundSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        mymaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
