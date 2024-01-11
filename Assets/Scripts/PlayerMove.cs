using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float maxxDist = 7.5f;
    float moveHorizontal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        if ((moveHorizontal > 0 && transform.position.x < maxxDist) || (moveHorizontal < 0 && transform.position.x > -maxxDist))
        {
            transform.position += Vector3.right * moveHorizontal * speed * Time.deltaTime;
        }
    }
}
