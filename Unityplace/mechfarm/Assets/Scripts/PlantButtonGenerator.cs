using Firebase;
using Firebase.Database;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantButtonGenerator : MonoBehaviour
{
    public GameObject plantButtonPrefab;  // 식물 버튼 프리팹
    public Transform buttonContainer;     // 버튼들이 생성될 부모 오브젝트

    private DatabaseReference reference;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            FirebaseApp app = FirebaseApp.DefaultInstance;
            reference = FirebaseDatabase.DefaultInstance.RootReference;

            // 로그인한 사용자의 식물 데이터를 가져옵니다.
            FetchPlants("leets");  // 예시로 "leets" 사용자의 식물 데이터를 가져옴
        });
    }

    void FetchPlants(string userName)
    {
        reference.Child("users").Child(userName).Child("plant").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                // 데이터를 가져오는데 문제가 발생했을 때
                Debug.LogError("Failed to fetch plant data.");
                return;
            }
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (DataSnapshot plant in snapshot.Children)
                {
                    Debug.Log(plant.Key);
                    // Debug.Log("buttonContainer" + buttonContainer);
                    Debug.Log(plantButtonPrefab);
                    CreatePlantButton(plant.Key);
                }
            }
        });
    }

    void CreatePlantButton(string plantName)
    {
        Debug.Log("createPlantbutton");
        GameObject newButton = Instantiate(plantButtonPrefab, buttonContainer);
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = plantName;
        // 이제 버튼 클릭 시 어떤 행동을 할지도 정의해야 합니다.
        Button buttonComponent = newButton.GetComponent<Button>();
        buttonComponent.onClick.AddListener(() => OnPlantButtonClicked(plantName));
    }

    void OnPlantButtonClicked(string plantName)
    {
        // 여기에 클릭 시 식물 정보를 표시하는 로직을 구현합니다.
        Debug.Log("Clicked plant: " + plantName);
    }
}
