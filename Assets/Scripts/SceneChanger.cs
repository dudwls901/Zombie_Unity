using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //아무 키나 누르면 Main 씬을 로드
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
