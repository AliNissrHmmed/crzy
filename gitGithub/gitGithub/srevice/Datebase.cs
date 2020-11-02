using gitGithub.Modal;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace gitGithub.srevice
{
  public class Datebase
    {
        public static void InitDb()
        {
            var embeddedResourceDb = Assembly.GetExecutingAssembly().
                GetManifestResourceNames().First(s => s.Contains("GodNames.db"));
            var embeddedResourceDbStream = Assembly.GetExecutingAssembly().
                GetManifestResourceStream(embeddedResourceDb);

            // Load data from bundle to phone cache on first launch
            if (!File.Exists(gitGithub_DATABASE_PATH))
            {
                using var br = new BinaryReader(embeddedResourceDbStream);
                using var bw = new BinaryWriter(new FileStream(gitGithub_DATABASE_PATH, FileMode.Create));
                var buffer = new byte[2048];
                int len;
                while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                {
                    bw.Write(buffer, 0, len);
                }
            }
            else
            {
                if (VersionTracking.IsFirstLaunchForCurrentVersion)
                {
                    File.Delete(gitGithub_DATABASE_PATH);
                    InitDb();
                }
            }
        }
        private static readonly string gitGithub_DATABASE_PATH = Path.Combine
     (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GodNames.db");

        private static SQLiteAsyncConnection conn;
        public static SQLiteAsyncConnection Connection
        {
            get
            {
                if (conn == null)
                    conn = new SQLiteAsyncConnection(gitGithub_DATABASE_PATH);
                return conn;
            }
        }
        public static Task<List<OhMyGod>> GetAll()
        {
            return Connection.Table<OhMyGod>().ToListAsync();
        }
    }
}
