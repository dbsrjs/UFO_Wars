using UnityEngine;

public class UFOController : MonoBehaviour
{
    public float rotationSpeed = 600f; // 각도 회전 속도
    public float speed = 0.001f;    // 비행 속도
    public float rotationAcceleration = 50f; // 회전 가속도

    private Rigidbody2D rd;
    private float currentRotationSpeed = 0f; // 현재 회전 속도

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Z축 회전 (A와 D 키에 따라 서서히 증가/감소)
        if (Input.GetKey(KeyCode.A))
        {
            currentRotationSpeed = Mathf.MoveTowards(currentRotationSpeed, rotationSpeed, rotationAcceleration * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currentRotationSpeed = Mathf.MoveTowards(currentRotationSpeed, -rotationSpeed, rotationAcceleration * 2 * Time.deltaTime);
        }
        else
        {
            // 키를 떼면 서서히 회전 속도를 0으로 줄임
            currentRotationSpeed = Mathf.MoveTowards(currentRotationSpeed, 0f, rotationAcceleration * Time.deltaTime);
        }

        transform.Rotate(Vector3.forward, currentRotationSpeed * Time.deltaTime);

        // 스페이스바로 전진
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 forwardDirection = transform.up; // 현재 Z축 기준 상방향
            rd.AddForce(forwardDirection * speed, ForceMode2D.Force);
        }
    }
}
