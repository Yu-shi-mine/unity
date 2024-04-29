using System.Collections.Generic;

using Setting;

namespace MyComponent
{
    interface IMyComponent
    {
        public void Initialize();

        public void LoadSetting<T>(T setting) where T : SettingBase;
    }
}
