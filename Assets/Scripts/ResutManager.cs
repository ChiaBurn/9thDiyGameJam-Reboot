using UnityEngine;

public class ResutManager : MonoBehaviour
{
    
    public void GoMainMenu()
    {
        PersistentManager.Instance.TransitScene(SceneEnum.MainMenu_Scene);
    }
}
