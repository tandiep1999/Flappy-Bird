using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flyPower = 80;

    public AudioClip flyClip;
    public AudioClip gameOverClip;

    private AudioSource audioSource;

    private Animator anim;
    GameObject obj;
    public GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = flyClip;
        anim = obj.GetComponent<Animator>();
        anim.SetFloat("flyPower", 0);
        anim.SetBool("isDead", false);
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetMouseButton(0) && gameController.GetComponent<GameController>().isRestart)
            {
                /*if (!gameController.GetComponent<GameController>().isEndGame) //nhớ dấu !
                {
                    audioSource.Play();
                }*/
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower));
            }
        anim.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y);
        // Một lưu ý khi xử lý va chạm:
        // Để xử lý va chạm giữa 2 vật thể, ít nhất MỘT TRONG HAI phải có RIGID BODY
        // và CẢ HAI phải có Collider (khi chọn thuộc tính trigger là có thể đi xuyên nhau)
        //Collision là va chạm, collider là đi xuyên (trigger). Nhìn hàm bên dưới là rõ

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndGame();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.GetComponent<GameController>().getPoint();
        audioSource.Play();
    }
    void EndGame()
    {
        //dùng để khi bird chạm vào vật thể
        //thì sẽ gọi hàm EndGame (ở bên trong script BirdController này)
        //sau đó hàm EndGame này sẽ lấy component từ object GameController (đã khởi tạo ở trong game)
        anim.SetBool("isDead", true);
        audioSource.clip = gameOverClip;
        audioSource.Play();
        gameController.GetComponent<GameController>().EndGame();
    }
}
