using UnityEngine;

// 플레이어 캐릭터를 조작하기 위한 사용자 입력을 감지
// 감지된 입력값을 다른 컴포넌트들이 사용할 수 있도록 제공
public class PlayerInput : MonoBehaviour {
    public string moveAxisName1 = "Vertical"; // 앞뒤 움직임을 위한 입력축 이름
    public string moveAxisName2 = "Horizontal"; // 좌우 회전을 위한 입력축 이름
    public string fireButtonName = "Fire1"; // 발사를 위한 입력 버튼 이름
    public string reloadButtonName = "Reload"; // 재장전을 위한 입력 버튼 이름

    // 값 할당은 내부에서만 가능
    
        //움직임을 Vertical, Horizontal 모두 받는다.
    public Vector3 move { get; private set; } // 감지된 움직임 입력값
    
    public bool fire { get; private set; } // 감지된 발사 입력값

    public bool laser { get; private set; }// 감지된 레이저 발사 입력값
    public bool reload { get; private set; } // 감지된 재장전 입력값

   
    // 매프레임 사용자 입력을 감지
    private void Update() {
        // 게임오버 상태에서는 사용자 입력을 감지하지 않는다
        if (GameManager.instance != null && GameManager.instance.isGameover)
        {
            move = Vector3.zero;

            laser = false;
            fire = false;
            reload = false;
            return;
        }

        // move에 관한 입력 감지
        //transform.right로 좌우 움직임을 추가
        move = Input.GetAxis(moveAxisName1)*transform.forward+ Input.GetAxis(moveAxisName2)*transform.right;
     
  
        // fire에 관한 입력 감지
        fire = Input.GetButton(fireButtonName);

        // 보조무기(laser)에 관한 입력 감지
        //마우스 우측 버튼
        laser = Input.GetMouseButtonDown(1);

        // reload에 관한 입력 감지
        reload = Input.GetButtonDown(reloadButtonName);
    }
}