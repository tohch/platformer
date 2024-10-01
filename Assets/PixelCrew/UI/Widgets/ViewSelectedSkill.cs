using PixelCrew.Creatures.Heroes;
using PixelCrew.Model;
using PixelCrew.Model.Definitions.Repositories;
using PixelCrew.Model.Models;
using PixelCrew.Utils.Disposables;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrew.UI.Widgets
{
    public class ViewSelectedSkill : MonoBehaviour
    {
        [SerializeField] private Image _skillIcon;
        [SerializeField] private PerkRepository _perks;

        private Hero _hero;
        private GameSession _session;
        private readonly CompositeDisposable _trash = new CompositeDisposable();

        void Start()
        {
            _hero = FindObjectOfType<Hero>();
            _session = FindObjectOfType<GameSession>();
            _trash.Retain(_session.PerksModel.Subscribe(UpdateUsedSkillIcon));
        }

        public void Update()
        {
            ShowIndicateSkill();
        }

        private void UpdateUsedSkillIcon()
        {
            if (_session.PerksModel.Used == "") return;

            var usedPerk = _session.PerksModel.Used;
            var newSkillIcon = _perks.Get(usedPerk).Icon;
            _skillIcon.sprite = newSkillIcon;
            _skillIcon.color = new Color(1f, 1f, 1f, 1f);
        }

        public void ShowIndicateSkill()
        {
            Debug.Log(_hero.Duration);
        }

        public void OnDestroy()
        {
            _trash.Dispose();
        }

    }
}