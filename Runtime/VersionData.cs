using Pixygon.ID;
using UnityEngine;

namespace Pixygon.Versioning
{
    [CreateAssetMenu(menuName = "New VersionData", fileName = "New VersionData")]
    public class VersionData : IdObject
    {
        public string Version;
        [TextArea] public string Changelog;
    }
}