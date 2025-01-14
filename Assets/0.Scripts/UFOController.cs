using UnityEngine;

public class UFOController : MonoBehaviour
{
    public float rotationSpeed = 600f; // ���� ȸ�� �ӵ�
    public float speed = 0.001f;    // ���� �ӵ�
    public float rotationAcceleration = 50f; // ȸ�� ���ӵ�

    private Rigidbody2D rd;
    private float currentRotationSpeed = 0f; // ���� ȸ�� �ӵ�

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Z�� ȸ�� (A�� D Ű�� ���� ������ ����/����)
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
            // Ű�� ���� ������ ȸ�� �ӵ��� 0���� ����
            currentRotationSpeed = Mathf.MoveTowards(currentRotationSpeed, 0f, rotationAcceleration * Time.deltaTime);
        }

        transform.Rotate(Vector3.forward, currentRotationSpeed * Time.deltaTime);

        // �����̽��ٷ� ����
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 forwardDirection = transform.up; // ���� Z�� ���� �����
            rd.AddForce(forwardDirection * speed, ForceMode2D.Force);
        }
    }
}
