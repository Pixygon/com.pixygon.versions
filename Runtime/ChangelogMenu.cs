using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Pixygon.Versioning {
    public class ChangelogMenu : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _versionText;
        [SerializeField] private GameObject _changelogPanel;
        [SerializeField] private TextMeshProUGUI _changelogText;
        [SerializeField] private RectTransform _textParent;
        [SerializeField] private UnityEvent _onCloseAction;
        [SerializeField] private GameObject _firstActive;
        private int _currentChangeLog;
        private VersionData[] _versions;

        public UnityEvent OnCloseAction => _onCloseAction;

        public void Initialize(VersionData[] versions) {
            _versions = versions;
            _versionText.text = "v" + _versions[_versions.Length - 1].Version;
        }
        public void OpenVersionLog() {
            _currentChangeLog = _versions.Length - 1;
            _changelogPanel.SetActive(true);
            EventSystem.current.SetSelectedGameObject(_firstActive);
            SetVersionLog();
        }
        public void MoveVersionLog(int i) {
            if (i == -1) {
                if (_currentChangeLog == 0) _currentChangeLog = _versions.Length - 1;
                else _currentChangeLog -= 1;
            } else if (i == 1) {
                if (_currentChangeLog == _versions.Length - 1) _currentChangeLog = 0;
                else _currentChangeLog += 1;
            }
            SetVersionLog();
        }
        private void SetVersionLog() {
            _changelogText.text = _versions[_currentChangeLog].Changelog;
            _textParent.sizeDelta = new Vector2(_textParent.sizeDelta.x, _changelogText.preferredHeight+100f);
        }

        public void OnCloseVersionLog() {
            _changelogPanel.SetActive(false);
            OnCloseAction?.Invoke();
        }
    }
}