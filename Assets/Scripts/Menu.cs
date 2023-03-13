using Game.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private Button dropSaveButton;
        [SerializeField] private Button exitButton;

        private EcsWorld ecsWorld;

        public void Init(EcsWorld ecsWorld)
        {
            this.ecsWorld = ecsWorld;

            dropSaveButton.onClick.AddListener(DropSave);
            exitButton.onClick.AddListener(Exit);
        }

        private void Exit()
        {
            Application.Quit();
        }

        private void DropSave()
        {
            ecsWorld.NewEntity().Get<DropSaveComponent>();
            Switch();
        }

        public void Switch()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
