using SixLabors.ImageSharp.Formats.Webp;
using System.IO;
using System.Windows.Forms;
using WebpConverter.dlls;
using static System.Net.WebRequestMethods;

namespace WebpConverter
{
    public partial class Form1 : Form
    {
        UserConfigurations? userConfig;

        public Form1()
        {
            InitializeComponent();
        }

        private async void button_Convert_File_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new())
            {
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (radioButton_DefaultPath.Checked && Directory.Exists(userConfig?.defaultPath))
                    openFileDialog.InitialDirectory = userConfig.defaultPath;
                else if (radioButton_LastPath.Checked && Directory.Exists(userConfig?.lastPath))
                    openFileDialog.InitialDirectory = userConfig.lastPath;

                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] files = openFileDialog.FileNames;

                    string? directory = Path.GetDirectoryName(files[0]);

                    userConfig?.SaveSettings(lastPath: directory);

                    RTConsole.Write("Processing...");

                    await Task.Run(() => Webp.Convert((int)userConfig?.defaultSize?["X"], (int)userConfig?.defaultSize?["Y"], (WebpEncodingMethod)userConfig?.defaultMethod, directory, files));

                    RTConsole.Write("Convert have been successfuly completed!\n");
                }
                else
                    RTConsole.Write("The operation has been canceled.\n");
            }
        }
        private async void button_Convert_Directory_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new())
            {
                folderDialog.Multiselect = true;

                if (radioButton_DefaultPath.Checked && Directory.Exists(userConfig?.defaultPath))
                    folderDialog.InitialDirectory = userConfig.defaultPath;
                else if (radioButton_LastPath.Checked && Directory.Exists(userConfig?.lastPath))
                    folderDialog.InitialDirectory = userConfig.lastPath;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] directories = folderDialog.SelectedPaths;

                    userConfig?.SaveSettings(lastPath: Path.GetDirectoryName(directories[0]));

                    RTConsole.Write("Processing...");

                    foreach (string i in directories)
                    {
                        RTConsole.Write($"Starting '{i}' directory...");

                        string[] fileExtentions = new string[] { "*.png", "*.jpg", "*.jpeg", "*.bmp" };

                        await Task.Run(() => Webp.Convert(
                            (int)userConfig?.defaultSize?["X"],
                            (int)userConfig?.defaultSize?["Y"],
                            (WebpEncodingMethod)userConfig?.defaultMethod,
                            i,
                            fileExtentions.SelectMany(ext => Directory.GetFiles(i, ext, SearchOption.TopDirectoryOnly)).ToArray()
                            ));

                        RTConsole.Write($"'{i}' is complete.\n");
                    }

                    RTConsole.Write("Convert have been successfuly completed!\n");
                }
                else
                    RTConsole.Write("The operation has been canceled.\n");
            }
        }
        private void button_SetDefaultFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new())
            {
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    userConfig?.SaveSettings(defaultPath: folderDialog.SelectedPath);

                    RTConsole.Write("New default path have been successfully saved!\n");
                }
                else
                    RTConsole.Write("The operation has been canceled.\n");
            }
        }
        private void _refreshCounter(string file)
        {
            RTConsole.Write($"{file} is complete.", Color.Green);
        }
        private void radioButton_DefaultPath_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userConfig?.defaultPath))
            {
                RTConsole.Write("Set the default folder before using it!\n");

                radioButton_LastPath.Checked = true;
            }
        }
        private void button_Save_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;

            int quality = 0;

            if (int.TryParse(textBox_X.Text, out x) && x >= 0 && x <= 5000)
                userConfig?.SaveSettings(defaultSize_X: x);
            else
            {
                RTConsole.Write("X can only be the numbers 0-5000!\n", Color.Red);

                textBox_X.Text = userConfig?.defaultSize?["X"].ToString();
            }

            if (int.TryParse(textBox_Y.Text, out y) && y >= 0 && y <= 5000)
                userConfig?.SaveSettings(defaultSize_Y: y);
            else
            {
                RTConsole.Write("Y can only be the numbers 0-5000!\n", Color.Red);

                textBox_Y.Text = userConfig?.defaultSize?["Y"].ToString();
            }

            if (int.TryParse(textBox_Quality.Text, out quality) && quality >= 0 && quality <= 100)
                userConfig?.SaveSettings(defaultQuality: quality);
            else
            {
                RTConsole.Write("Quality can only be the numbers 0-100!\n", Color.Red);

                textBox_Quality.Text = userConfig?.defaultQuality.ToString();
            }

            RTConsole.Write("Save operation is complete.\n");
        }
        private void button_Restore_Click(object sender, EventArgs e)
        {
            textBox_X.Text = userConfig?.defaultSize?["X"].ToString();
            textBox_Y.Text = userConfig?.defaultSize?["Y"].ToString();
            textBox_Quality.Text = userConfig?.defaultQuality.ToString();

            RTConsole.Write("Restore operation is complete.\n");
        }
        private void comboBox_Methods_TextUpdate(object sender, EventArgs e)
        {
            comboBox_Methods.SelectedItem = userConfig?.defaultMethod;
        }

        private void comboBox_Methods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Methods.SelectedIndex == -1) return;

            userConfig?.SaveSettings(defaultMethod: (WebpEncodingMethod)comboBox_Methods.SelectedItem);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            RTConsole.Init(ref rt_Console);
            userConfig = new(@"data\userConfig.cfg");

            textBox_X.Text = userConfig?.defaultSize?["X"].ToString();
            textBox_Y.Text = userConfig?.defaultSize?["Y"].ToString();
            textBox_Quality.Text = userConfig?.defaultQuality.ToString();

            radioButton_LastPath.Checked = true;

            comboBox_Methods.Items.AddRange(
                WebpEncodingMethod.Level0,
                WebpEncodingMethod.Level1,
                WebpEncodingMethod.Level2,
                WebpEncodingMethod.Level3,
                WebpEncodingMethod.Level4,
                WebpEncodingMethod.Level5,
                WebpEncodingMethod.Level6
                );

            switch(userConfig?.defaultMethod)
            {
                case WebpEncodingMethod.Level0:
                    comboBox_Methods.SelectedIndex = 0;
                    break;
                case WebpEncodingMethod.Level1:
                    comboBox_Methods.SelectedIndex = 1;
                    break;
                case WebpEncodingMethod.Level2:
                    comboBox_Methods.SelectedIndex = 2;
                    break;
                case WebpEncodingMethod.Level3:
                    comboBox_Methods.SelectedIndex = 3;
                    break;
                case WebpEncodingMethod.Level4:
                    comboBox_Methods.SelectedIndex = 4;
                    break;
                case WebpEncodingMethod.Level5:
                    comboBox_Methods.SelectedIndex = 5;
                    break;
                case WebpEncodingMethod.Level6:
                    comboBox_Methods.SelectedIndex = 6;
                    break;
                default:
                    comboBox_Methods.SelectedIndex = 1;
                    break;
            }

            Webp._refreshCounter += _refreshCounter;

            try
            {
                string version = System.IO.File.ReadAllText(Directory.GetFiles("../../../", "version.txt", SearchOption.TopDirectoryOnly)[0]);

                label_Version.Text = version;
            }
            catch { }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
