using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유니티에서 다른 씬(Scene)을 관리(불러오기 등)를 하는 기능을 이 스크립트에 포함한다.
// 사용하기위해서 포함한다...
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    // Public: "외부에서" 해당 클래스에 접근시 사용 가능!
    // Private: "외부에서" 해당 클래스에 접근시 사용 불가!
    // Protected "외부에서" 해당 클래스에 접근시 사용 불가 하지만, 상속을 받은 자식 객체에서는 사용 가능!

    private void Awake()
    {
        // Awake는 오브젝트가 비활성화되어 있어도 "씬"을 로드하면 호출됨!
        // Start보다 먼저 호출됨!
        
        // Debug 함수는 유니티 "개발자"들이 볼 수 있도록 문자열을 "Console"에 출력해주는 기능
        // Debug.Log("Awake 호출됨!");
    }

    void Start()
    {
        // Start는 오브젝트가 비활성화되어 있으면 "씬"이 로드 되어도 호출되지 않음!
        // Start는 호출되지 않았다면, 최초 1회 활성화되면 호출됨!
        
        // Debug.Log("Start 호출됨!");
    }

    // Update is called once per frame
    void Update()
    {
        // Update는 해당 오브젝트가 활성화 되어있으면 매 프레임마다 호출된다
        // 60FPS -> 1초에 60번 호출 ...

        // Debug.Log("Update 호출됨!");
    }

    /// <summary>
    /// BTN? Button의 약자, 버튼에서 호출되는 함수...
    /// 방에 접속하는 버튼
    /// </summary>
    public void BTN_JoinRoom()
    {
        Debug.Log("버튼이 눌림");

        // 다른 맵(Scene)을 불러와 함....

        // 유니티에서 제공하는 "씬 매니저"라는 기능을 이용해서 다른 Scene을 불러온다...
        // UnityEngine.SceneManagement를 이 스크립트에 포함해서 그 기능을 불러온다...

        // LoadScene에서 불러올 씬 이름? -> Scene "파일"의 이름
        // "Room"이라는 Scene을 불러오기 위해서는 빌드세팅(Build Settings)에 "Room"이라는 씬을 로드해놔야한다(사용하기로 설정한다)
        
        // 1. 유니티 에디터 상단 왼쪽의 File -> Build Settings에 들어간다
        // 2. Build Settings 상단의 Scenes In Build 영역에 "Room" 씬 파일을 포함

        // 유니티에 있는 기능을 사용하여 "Room"이라는 씬을 "즉시" 불러온다 (로딩 화면 없이... 게임이 멈춤!!!!!!!!)
        SceneManager.LoadScene("Corridor");

        // 구현한 기능으로 "Room"이라는 씬을 "비동기"로 불러오며, 로딩 된 양에 따라 로딩바가 점점 차며 로드한다..
        // 이 기능을 이용하기 위해서는 Resources 폴더에 "LoadingUI"가 있어야 함(기본값)
        // 사용하려면 주석 해제하세요!
        // LoadingSceneController.Instance.LoadScene("Room");
    }
}