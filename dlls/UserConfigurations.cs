using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources.Tools;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;
using SixLabors.ImageSharp.Formats.Webp;

namespace WebpConverter.dlls
{
    internal class UserConfigurations : IDisposable
    {
        public string? defaultPath;
        public string? lastPath;

        public int defaultWidth;
        public int defaultHeight;

        public int defaultQuality;
        public WebpEncodingMethod defaultMethod;

        private readonly string? pathToConfig;

        public UserConfigurations(string pathToConfig)
        {
            this.pathToConfig = pathToConfig;

            try
            {
                UserConfigurations? tempConf;

                if (!Directory.Exists(Path.GetDirectoryName(pathToConfig)))                
                    Directory.CreateDirectory(Path.GetDirectoryName(pathToConfig) ?? string.Empty);
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
            defaultWidth = userConf.defaultWidth;
            defaultHeight = userConf.defaultHeight;
            defaultQuality = userConf.defaultQuality;
            defaultMethod = userConf.defaultMethod;
        }

        public void SaveSettings(string? defaultPath = null, string? lastPath = null, int? defaultWidth = null, int? defaultHeight = null, int? defaultQuality = null, WebpEncodingMethod? defaultMethod = null)
        {
            if (defaultPath is not null) this.defaultPath = defaultPath;
            if (lastPath is not null) this.lastPath = lastPath;

            if (defaultWidth is not null) this.defaultWidth = (int)defaultWidth;
            if (defaultHeight is not null) this.defaultHeight = (int)defaultHeight;

            if (defaultQuality is not null) this.defaultQuality = (int)defaultQuality;

            if (defaultMethod is not null) this.defaultMethod = (WebpEncodingMethod)defaultMethod;

            string userConf = JsonConvert.SerializeObject(this);

            try
            {
                if (!string.IsNullOrEmpty(pathToConfig))
                    File.WriteAllText(pathToConfig, userConf);
            }
            catch (Exception e) { RTConsole.Write($"Unable to save user configuration file. {e.Message}", Color.Red); };
        }

        private UserConfigurations GetDefault()
        {
            UserConfigurations userConfig = new();

            defaultWidth = 656;
            defaultHeight = 630;

            userConfig.defaultQuality = 0;

            return userConfig;
        }

        public void Dispose()
        {
            defaultPath = null;
            lastPath = null;
        }
    }
}
