
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] GameObject groundFloor;
    Vector3 nextSpawnTile;

    public void SpawnTile (bool spawnItems)
    {
        GameObject temp = Instantiate(groundFloor, nextSpawnTile, Quaternion.identity);
        nextSpawnTile = temp.transform.GetChild(1).transform.position;
    }


    // Start is called before the first frame update
    private void Start () {
        for (int i = 0; i < 30; i++) {
            if (i < 3) {
                SpawnTile(false);
            } else {
                SpawnTile(true);
            }
        }
        }

}