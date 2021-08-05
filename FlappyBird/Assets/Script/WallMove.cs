using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    public float moveSpeed; //quy ước đặt tên của Unity...
    public float minY;
    public float maxY;

    public float oldPosition; // dùng để lưu lại position cũ
    // với trường hợp này là x thôi, nên không cần xài vector3
    private GameObject obj; // mẹo nhỏ dùng để tăng tốc script, tạo object obj thể hiện đây là object mà script nhận vào
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPosition = 10;
        moveSpeed = 5;
        minY = -1;
        maxY = 1;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.Translate(-1 * Time.deltaTime * moveSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Reset"))
        {
            obj.transform.position = new Vector3(oldPosition, Random.Range(minY, maxY + 1), 0);
        }
    }
}
