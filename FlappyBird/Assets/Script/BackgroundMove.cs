using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float moveSpeed; //quy ước đặt tên của Unity...
    public float moveRange; //khoảng cách move

    private Vector3 oldPosition; // dùng để lưu lại position cũ
    private GameObject obj; // mẹo nhỏ dùng để tăng tốc script, tạo object obj thể hiện đây là object mà script nhận vào
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        oldPosition = obj.transform.position;
        moveSpeed = 5;
        moveRange = 13; // nếu xài số lẻ thì phải ghi là moveRange = 13.5f;
    }

    // Update is called once per frame
    void Update()
    {
        /* thay đổi position bằng cách xài new, new là để tạo một position mới luôn
    có Vector2 và Vector3, Vector2 là x, y; Vector 3 là x, y, z
    Ở đây trong Unity mình đang xài x, y, z. Với 2D thì z = 0 */
        // deltaTime là khoảng cách giữa 2 frame của game

        //transform.position = new Vector3((transform.position.x - 1) * Time.deltaTime, transform.position.y, 0);
        
        //tuy nhiên có cách khác hay hơn

        //gọi hàm Translate
        //tham số của hàm là vecto, hàm sẽ cộng vector này vào position có sẵn của vật thể
        //nói cách khác, vật thể sẽ di chuyển theo hướng vector đã truyền vào hàm

        //transform.Translate(new Vector3(-1 * Time.deltaTime, transform.position.y, 0));
        //transform.Translate(-1 * Time.deltaTime, 0, 0);
        
        // thêm vào moveSpeed
        obj.transform.Translate(-1 * Time.deltaTime * moveSpeed, 0, 0);

        //hàm Distance dùng để tính khoảng cách giữa 2 vector
        if (Vector3.Distance(oldPosition, obj.transform.position) > moveRange)
        { // như vậy tùy theo Move Range mà mình chọn, khi vật thể đi tới khoảng cách đó nó sẽ tự trở về old position
            obj.transform.position = oldPosition;
        }

    }
}
