using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SoInstaller", menuName = "Create SO installer")]
public class SoInstaller : ScriptableObjectInstaller<SoInstaller>
{

    [SerializeField] private GameConfig gameConfig;

    public override void InstallBindings()
    {
        Container.BindInstance(gameConfig);
    }
}