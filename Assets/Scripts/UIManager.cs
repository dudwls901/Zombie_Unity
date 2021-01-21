using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리자 관련 코드
using UnityEngine.UI; // UI 관련 코드

// 필요한 UI에 즉시 접근하고 변경할 수 있도록 허용하는 UI 매니저
public class UIManager : MonoBehaviour
{

    

    // 싱글톤 접근용 프로퍼티
    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }

            return m_instance;
        }
    }

    private static UIManager m_instance; // 싱글톤이 할당될 변수
    public Text ammoText; // 탄약 표시용 텍스트
    public Text scoreText; // 점수 표시용 텍스트
    public Text waveText; // 적 웨이브 표시용 텍스트
    public GameObject gameoverUI; // 게임 오버시 활성화할 UI
    

    public GameObject[] Bullet;// 탄약 표시용 그림 배열
    public GameObject laserAmmoImage;//보조무기 탄약 표시용 이미지
    public Text laserAmmoText; //보조무기 탄약 표시용 텍스트
    
    // 탄약 텍스트 갱신
    public void UpdateAmmoText(int magAmmo, int remainAmmo)
    {
        ammoText.text = magAmmo + "/" + remainAmmo;

        //탄창을 생성해 놓고 탄창 갯수만큼 setActive(true)로 화면에 보여준다.
        for (int i = 1; i < 10; i++)
            Bullet[i].SetActive(false);
        int bulletAll = magAmmo + remainAmmo;
        int bullet25 = 25;
        int magasin;
        if (bulletAll % bullet25 > 0)
        {
            magasin = bulletAll / bullet25 + 1;
        }
        else
        {
            magasin = bulletAll / bullet25;
        }

        for (int i = 1; i <= magasin; i++)
        {
            Bullet[i].SetActive(true);

            //장전한 탄창의 총알이 떨어질 수록 탄창의 fillAmount를 감소시킨다.
            if (i == magasin)
                Bullet[magasin].GetComponent<Image>().fillAmount = magAmmo * 0.04f;
            else
            {
                Bullet[i].GetComponent<Image>().fillAmount = 1f;
            }
        }

 
    }

    //보조무기 탄약 텍스트 갱신
    public void UpdateAmmoText1(int magAmmo )
    {
        //보조무기의 탄약이 0 이상이면 화면에 띄어준다.
        if (magAmmo > 0)
        {
            laserAmmoImage.SetActive(true);
            laserAmmoText.text = "" + magAmmo;
        }
        else 
        {
            laserAmmoImage.SetActive(false);
        }

    }

    // 점수 텍스트 갱신
    public void UpdateScoreText(int newScore)
    {
        scoreText.text = "Score : " + newScore;
    }

    // 적 웨이브 텍스트 갱신
    public void UpdateWaveText(int waves, int count)
    {
        waveText.text = "Wave : " + waves + "\nEnemy Left : " + count;
    }

    // 게임 오버 UI 활성화
    public void SetActiveGameoverUI(bool active)
    {
        gameoverUI.SetActive(active);
    }

    // 게임 재시작
    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    //인트로화면으로 이동
    public void GotoMain()
    {
        SceneManager.LoadScene("Intro");
    }
}