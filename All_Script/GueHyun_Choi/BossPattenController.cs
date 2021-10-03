using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattenController : MonoBehaviour
{ // 공격을 위한 컨트롤러
    Vector3 playerPos;                // 플레이어의 위치 저장
    public GameObject Atk1;           // 공격 오브젝트
    Vector3 whereToAtk;               // 공격 위치
    private bool isAttacking = false; // 지금 공격 중인지 확인

    private void OnTriggerStay(Collider other) // isTrigger 통과가능한 물체와 부딫히고있으면 프레임당 실행
    { // 현재는 필드의 Cube오브젝트에 붙여 사용, 오브젝트 안에 들어오면 실행
        if (other.tag == "Player") // 부딪힌 오브젝트가 Player일 경우 실행
        {
            playerPos = other.transform.position; // 플레이어 위치 전달
            StartCoroutine("BeforeAttack"); // BeforeAttack 이라는 코루틴 함수 호출
        }
    }
    IEnumerator BeforeAttack() // 공격을 위한 함수
    {
        if (isAttacking == false) // 공격 중이 아닐 경우에만 실행
        {
            whereToAtk = new Vector3(playerPos.x, 0, playerPos.z); // 플레이어 위치 전달
            isAttacking = true; // 공격 중
            
            Debug.Log("Attack 시작"); // 실행 확인을 위한 로그

            yield return new WaitForSeconds(1f); // 1초뒤에 진행
            Instantiate(Atk1, whereToAtk, transform.rotation); // 위에서 받은 플레이어 위치에 공격 소환

            Debug.Log(isAttacking); // 실행 확인을 위한 로그
            isAttacking = false; // 공격 종료
        }
    }

}