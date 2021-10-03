using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody playerRb; // 플레이어의 RigidBody 저장용
    public float hitPower = 300f;

    public float speed;
    public float rotateSpeed;
    float hAxis;
    float vAxis;

    public Vector3 moveVec;

    Animator anim;
    
    void Walk()
    {

        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * Time.deltaTime;
        Turn();
    }

    void Turn()
    {
        if (hAxis == 0 && vAxis == 0)
            return;
        Quaternion newRotation = Quaternion.LookRotation(moveVec * speed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
    }

    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>(); // 플레이어의 RigidBody를 가져옴

        //anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Walk();
        //anim.SetBool("isRun", moveVec != Vector3.zero);
    }

    private void OnTriggerEnter(Collider other) // 공격과 닿을 때 실행
    {
        if (other.tag == "Attack") // 닿은 물체가 공격인지 확인
        {
            Debug.Log("반응!@!!"); // 확인을 위한 로그

            Vector3 hitVector = new Vector3(transform.position.x - other.transform.position.x, 0,
                transform.position.z - other.transform.position.z);

            StartCoroutine(OnDamage(hitVector));
        }
    }

    IEnumerator OnDamage(Vector3 hitVector)
    {
        hitVector = hitVector.normalized;
        hitVector += Vector3.up;

        Debug.Log(hitVector);

        playerRb.AddForce(hitVector * 500);

        yield return new WaitForSeconds(0.1f);
    }

}