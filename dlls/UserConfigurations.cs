using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources.Tools;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace WebpConverter.dlls
{
    internal class UserConfigurations : IDisposable
    {
        public string? defaultPath;
        public string? lastPath;
        public Dictionary<string, int>? defaultSize;
        public int? defaultQuality;

        private readonly string pathToConfig;

        public UserConfigurations(string pathToConfig)
        {
            this.pathToConfig = pathToConfig;

            try
            {
                UserConfigurations? tempConf;

                if (!Directory.Exists(Path.GetDirectoryName(pathToConfig)))
                    Directory.CreateDirectory(Path.GetDirectoryName(pathToConfig));
                if (!File.Exists(pathToConfig))
                {
                    tempConf = GetDefault();

                    File.WriteAllText(pathToConfig, JsonConvert.SerializeObject(tempConf));
                }
                else
                {
                    string config = File.ReadAllText(pathToConfig);
                    
                    tempConf = JsonConvert.DeserializeObject<UserConfigurations>(config);

                    if (tempConf is null)
                        throw new Exception("User configurations is not found.");
                }

                Init(tempConf);
            }
            catch (Exception e) { RTConsole.Write(e.Message, Color.Red); }
        }
        public UserConfigurations() { }
        private void Init(UserConfigurations userConf)
        {
            defaultPath = userConf.defaultPath;
            lastPath = userConf.lastPath;
            defaultSize = userConf.defaultSize;
            defaultQuality = userConf.defaultQuality;
        }

        public void SaveSettings(string? defaultPath = null, string? lastPath = null, int? defaultSize_X = null, int? defaultSize_Y = null, int? defaultQuality = null)
        {
            if (defaultPath is not null) this.defaultPath = defaultPath;
            if (lastPath is not null) this.lastPath = lastPath;

            if (defaultSize_X is not null) this.defaultSize["X"] = (int)defaultSize_X;
            if (defaultSize_Y is not null) this.defaultSize["Y"] = (int)defaultSize_Y;

            if (defaultQuality is not null) this.defaultQuality = defaultQuality;

            string userConf = JsonConvert.SerializeObject(this);

            try
            {
                File.WriteAllText(pathToConfig, userConf);
            }
            catch (Exception e) { RTConsole.Write($"Unable to save user configuration file. {e.Message}", Color.Red); };
        }

        private UserConfigurations GetDefault()
        {
            UserConfigurations userConfig = new();

            userConfig.defaultSize = new Dictionary<string, int>
            {
                { "X", 656 },
                { "Y", 630 }
            };

            userConfig.defaultQuality = 0;

            return userConfig;
        }

        public void Dispose()
        {
            defaultSize?.Clear();
            defaultSize = null;

            defaultPath = null;
            lastPath = null;
            defaultQuality = null;
        }
    }
}
