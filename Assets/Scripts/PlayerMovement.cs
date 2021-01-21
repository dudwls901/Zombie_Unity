using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

// 플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5f; // 앞뒤 움직임의 속도
    public float rotateSpeed = 0.1f; // 좌우 회전 속도
 
    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터
  
    private void Start() {
        // 사용할 컴포넌트들의 참조를 가져오기
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
  
    }

    //update : 화면 갱진 주기로 실행
    // FixedUpdate는 물리 갱신 주기에 맞춰 실행됨(0.02초)
    private void FixedUpdate() {
        // 물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행
        Rotate();
        Move();
        playerAnimator.SetFloat("Move", playerInput.move.magnitude);
       
    }

    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void Move() {
        
        //상대적으로 이동할 거리 계산
        Vector3 moveDistance = playerInput.move  * moveSpeed * Time.deltaTime;
        //리지드바디를 이용해 게임 오브젝트 위치 변경
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }
    // 입력값에 따라 캐릭터를 좌우로 회전
    private void Rotate() {

        //마우스 방향으로 플레이어 방향전환
        //마우스의 위치를 ScreenPointToRay를 이용해 카메라로 부터의 스크린의 점을 통해 레이를 반환한다.
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //월드 좌표로 하늘방향에 크기가 1인 단위 백터와 원점을 갖는다.
        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;


        //레이가 평면과 교차했는지 여부를 체크한다.
        if (GroupPlane.Raycast(cameraRay, out rayLength))

        {
            //rayLenghth거리에 위치값을 반환한다.
            Vector3 pointTolook = cameraRay.GetPoint(rayLength);

            //위에서 구한 pointTolook 위치값을 캐릭터가 바라 보도록 한다.
            transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));

        }


    }
}