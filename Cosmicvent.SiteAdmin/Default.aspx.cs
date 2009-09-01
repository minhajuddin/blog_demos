using System;
using System.IO;
using System.Web.Security;

namespace Cosmicvent.SiteAdmin {
    public partial class _Default : System.Web.UI.Page {
        private const string VALID_USERNAME = "administrator";
        private const string VALID_HASHED_PASSWORD = "8D31D551A44B2DE3DFFA85842ABF38A8ACF14775";
        private const string APP_OFFLINE_PATH = @"C:\";
        private const string APP_OFFLINE_BACKUP_NAME = "app_offline.htm.bak";
        private const string APP_OFFLINE_FILE_NAME = "app_offline.htm";
        private const string APP_OFFLINE_CONTENT = @"<html>
            <head><title>The site has been taken offline for Maintenance</title></head>
            <body>
                <h2>The site has been taken offline for maintenance</h2>
                <p>We are sorry for the incovenience. Please check back again some time later</p>
                <!-- 
                    Here is some junk data for you IE !!!
                    Go to http://minhajuddin.com
                    Go to http://minhajuddin.com
                    Go to http://minhajuddin.com
                    Go to http://minhajuddin.com
                    Go to http://minhajuddin.com
                    Go to http://minhajuddin.com
                    Go to http://minhajuddin.com
                    Go to http://minhajuddin.com
                    Go to http://minhajuddin.com
                    Go to http://minhajuddin.com
                    Go to http://minhajuddin.com
                    Go to http://minhajuddin.com
                    Go to http://minhajuddin.com
                    Go to http://minhajuddin.com
                    Go to http://minhajuddin.com
                    Go to http://minhajuddin.com
                    Go to http://minhajuddin.com
                -->
            </body>
        </html>";

        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void SubmitButton_Click(object sender, EventArgs e) {
            if (UserIsValid()) {
                string backupFilePath = Path.Combine(APP_OFFLINE_PATH, APP_OFFLINE_BACKUP_NAME);
                string appOfflineFilePath = Path.Combine(APP_OFFLINE_PATH, APP_OFFLINE_FILE_NAME);
                if (TakeOfflineRadioButton.Checked) {
                    //create or rename the backup file
                    if (File.Exists(backupFilePath) && !File.Exists(appOfflineFilePath)) {
                        //rename
                        RenameFile(backupFilePath, appOfflineFilePath);
                    } else if (!File.Exists(appOfflineFilePath)) {
                        //create
                        CreateAppOffline(appOfflineFilePath);
                    }
                    output.InnerText = "Site taken down successfully";
                } else if (BringUpOnlineRadioButton.Checked) {
                    //rename the app_ofline file
                    if (File.Exists(appOfflineFilePath)) {
                        //rename
                        RenameFile(appOfflineFilePath, backupFilePath);
                    }
                    output.InnerText = "Site brought up successfully";
                }
            } else {
                output.InnerText = "Invalid username or password";
            }
        }

        private void CreateAppOffline(string appOfflineFilePath) {
            using (StreamWriter streamWriter = File.CreateText(appOfflineFilePath)) {
                streamWriter.Write(APP_OFFLINE_CONTENT);
            }
        }

        private void RenameFile(string backupFilePath, string appOfflineFilePath) {
            File.Move(backupFilePath, appOfflineFilePath);
        }

        private bool UserIsValid() {
            return VALID_USERNAME.Equals(UserName.Text, StringComparison.OrdinalIgnoreCase) &&
                   VALID_HASHED_PASSWORD.Equals(Hash(Password.Text), StringComparison.OrdinalIgnoreCase);
        }

        private string Hash(string text) {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(text, "SHA1");
        }
    }
}
