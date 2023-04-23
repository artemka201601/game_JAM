using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCWeight
{
    public GameObject npcPrefab;
    public int weight;
}

public class NPCSpawner : MonoBehaviour
{
    public NPCWeight[] npcWeights;
    public float spawnRadius = 20f;
    public Transform player;
    public int maxNPCs = 50;

    private List<GameObject> npcs = new List<GameObject>();

    void Start()
    {
        // Запускаем корутину, чтобы создавать NPC каждые 5 секунд
        StartCoroutine(SpawnRoutine());
    }

    void Update()
    {
        // Перебираем список созданных NPC и удаляем те, которые находятся на расстоянии более 500 единиц от игрока
        for (int i = npcs.Count - 1; i >= 0; i--)
        {
            GameObject npc = npcs[i];
            if (Vector3.Distance(player.position, npc.transform.position) > 50f)
            {
                npcs.RemoveAt(i);
                Destroy(npc);
            }
        }
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            if (npcs.Count < maxNPCs)
            {
                // Выбираем случайный префаб NPC на основе весов
                int totalWeight = 0;
                foreach (NPCWeight npcWeight in npcWeights)
                {
                    totalWeight += npcWeight.weight;
                }

                int randomWeight = Random.Range(0, totalWeight);
                int cumulativeWeight = 0;
                GameObject selectedPrefab = null;

                foreach (NPCWeight npcWeight in npcWeights)
                {
                    cumulativeWeight += npcWeight.weight;
                    if (randomWeight < cumulativeWeight)
                    {
                        selectedPrefab = npcWeight.npcPrefab;
                        break;
                    }
                }

                // Генерируем случайную позицию внутри заданного радиуса от игрока
                Vector2 randomPos = Random.insideUnitCircle.normalized * Random.Range(15f, 30f);
                Vector3 spawnPos = player.position + new Vector3(randomPos.x, 0f, -0.34f);

                // Создаем нового NPC из выбранного префаба и добавляем его в список
                GameObject npc = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
                npcs.Add(npc);
            }

            // Ждем 2 секунды перед следующим созданием NPC
            yield return new WaitForSeconds(2f);
        }
    }
}