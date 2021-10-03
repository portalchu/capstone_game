using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattenController : MonoBehaviour
{ // ������ ���� ��Ʈ�ѷ�
    Vector3 playerPos;                // �÷��̾��� ��ġ ����
    public GameObject Atk1;           // ���� ������Ʈ
    Vector3 whereToAtk;               // ���� ��ġ
    private bool isAttacking = false; // ���� ���� ������ Ȯ��

    private void OnTriggerStay(Collider other) // isTrigger ��������� ��ü�� �΋H���������� �����Ӵ� ����
    { // ����� �ʵ��� Cube������Ʈ�� �ٿ� ���, ������Ʈ �ȿ� ������ ����
        if (other.tag == "Player") // �ε��� ������Ʈ�� Player�� ��� ����
        {
            playerPos = other.transform.position; // �÷��̾� ��ġ ����
            StartCoroutine("BeforeAttack"); // BeforeAttack �̶�� �ڷ�ƾ �Լ� ȣ��
        }
    }
    IEnumerator BeforeAttack() // ������ ���� �Լ�
    {
        if (isAttacking == false) // ���� ���� �ƴ� ��쿡�� ����
        {
            whereToAtk = new Vector3(playerPos.x, 0, playerPos.z); // �÷��̾� ��ġ ����
            isAttacking = true; // ���� ��
            
            Debug.Log("Attack ����"); // ���� Ȯ���� ���� �α�

            yield return new WaitForSeconds(1f); // 1�ʵڿ� ����
            Instantiate(Atk1, whereToAtk, transform.rotation); // ������ ���� �÷��̾� ��ġ�� ���� ��ȯ

            Debug.Log(isAttacking); // ���� Ȯ���� ���� �α�
            isAttacking = false; // ���� ����
        }
    }

}