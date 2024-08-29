using PixelCrew.Components.Dialogs;
using PixelCrew.Model.Definitions;
using System;
using System.Collections;
using UnityEngine;

namespace PixelCrew.Creatures.Mobs
{
    public class AnswerToCrabby : MonoBehaviour
    {
        [SerializeField] private ShowDialogComponent _showDialogComponent;
        [SerializeField] private DialogDef _dialog;

        public void Start()
        {
            _showDialogComponent = GetComponent<ShowDialogComponent>();
            StartCoroutine(Answer());
        }

        private IEnumerator Answer()
        {
            yield return new WaitForSeconds(3f);
            _showDialogComponent.Show(_dialog);
        }
    }
}