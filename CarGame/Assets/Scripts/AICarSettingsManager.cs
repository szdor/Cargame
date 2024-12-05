using UnityEngine;
using UnityEngine.UI;

public class AICarSettingsManager : MonoBehaviour
{
    // AI autók
    public AICar[] aiCarOptions;
    private AICar selectedCar;

    // UI elemek
    public Dropdown carDropdown;
    public Button spawnCarButton;

    // Pálya beállítások
    public Transform spawnPoint; // Spawn hely a kiválasztott AI autónak

    private void Start()
    {
        // Dropdown opciók inicializálása
        carDropdown.ClearOptions();
        var options = new System.Collections.Generic.List<string>();
        foreach (var car in aiCarOptions)
        {
            options.Add(car.name);
        }
        carDropdown.AddOptions(options);

        // Alapértelmezett autó beállítása
        selectedCar = aiCarOptions[0];

        // Eseménykezelők hozzáadása
        carDropdown.onValueChanged.AddListener(OnCarSelected);
        spawnCarButton.onClick.AddListener(OnSpawnCarButtonClicked);
    }

    private void OnCarSelected(int index)
    {
        // Kiválasztott AI autó frissítése
        selectedCar = aiCarOptions[index];
        Debug.Log($"Selected Car: {selectedCar.name}");
    }

    private void OnSpawnCarButtonClicked()
    {
        // AI autó indítása
        if (selectedCar != null && spawnPoint != null)
        {
            var spawnedCar = Instantiate(selectedCar, spawnPoint.position, spawnPoint.rotation);

            // Nehézségi szint beállítása
            spawnedCar.SetDifficulty("Easy");

            Debug.Log($"Spawned Car: {spawnedCar.name} with Difficulty: Easy");
        }
        else
        {
            Debug.LogWarning("Selected car or spawn point is null!");
        }
    }
}
