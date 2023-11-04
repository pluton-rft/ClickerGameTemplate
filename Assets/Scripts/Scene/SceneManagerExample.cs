namespace Clicker.Architecture {
    public sealed class SceneManagerExample : SceneManagerBase {
        public override void InitSceneMap() {
            sceneConfigMap[SceneConfigExample.SCENE_NAME] = new SceneConfigExample();
        }
    }
}