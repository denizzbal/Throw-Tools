using UnityEngine;

public class PlatformManager: MonoBehaviour
{
    [SerializeField] LevelControl levelControl;

    private void Awake()
    {
        PlatformSet();
    }

    void PlatformSet()
    {
        if(transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
            GameObject Platform1 = Instantiate(levelControl.Platform, transform.position, levelControl.Platform.transform.rotation);
            Platform1.transform.SetParent(transform);
        }
        else
        {
            GameObject Platform = Instantiate(levelControl.Platform, transform.position, levelControl.Platform.transform.rotation);
            Platform.transform.SetParent(transform);
        }
         

        
    }
}
