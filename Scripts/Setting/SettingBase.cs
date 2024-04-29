
namespace Setting
{
    [System.Serializable]
    public abstract class SettingBase
    {
        // Inheritance
        [UnityEngine.SerializeReference]
        protected string _path;
        public abstract string Type { get; }

        // Constructor
        public SettingBase(string path)
        {
            _path = path;
        }

        // Property
        public string Path
        {
            get { return _path; }
        }
    }
}
