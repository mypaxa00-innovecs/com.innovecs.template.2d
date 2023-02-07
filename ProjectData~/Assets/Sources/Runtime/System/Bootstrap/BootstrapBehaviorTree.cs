using Innovecs.Addressables;
using Innovecs.BehaviorTree;
using Innovecs.BehaviorTree.Unity3D;
using Zenject;

public sealed class BootstrapBehaviorTree : MonoBehaviorTree
{
    [Inject] private readonly LoadedScenesState m_loadedScenesState = default;

    public override INode Execute()
    {
        return new Sequence(
            new LoadSceneAsAddressableAsync(Scenes.System.Audio, m_loadedScenesState),
            new LoadSceneAsAddressableAsync(Scenes.System.Input, m_loadedScenesState),
            new LoadSceneAsAddressableAsync(Scenes.System.Camera, m_loadedScenesState),
            new UnloadSceneByNameAsync(Scenes.System.Bootstrap)
        );
    }
}
