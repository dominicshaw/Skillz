using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using Skillz.ViewModel;

namespace Skillz.Models
{
    public class CSVResult
    {
        public string Username { get; set; }
        public string Error { get; set; }
        public List<SkillLevelViewModel> Skills { get; } = new List<SkillLevelViewModel>();
    }

    public class CSVLoader
    {
        public async Task<CSVResult> ReadHighscore(string username)
        {
            var result = new CSVResult
            {
                Username = username
            };

            try
            {
                using(var client = new WebClient())
                {
                    //var data = await client.DownloadStringTaskAsync($"http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player={username}");
                    var data = "700011,720,4659320\n" + "915654,44,57031\n" + "1537440,8,875\n" + "971018,47,80751\n" + "1364084,34,20934\n" + "1651307,1,52\n" + "1055036,20,4689\n" + "917519,44,57310\n" + "1272970,14,2368\n" + "652384,52,125142\n" + "898684,10,1170\n" + "158056,72,949286\n" + "100496,75,1210683\n" + "900832,31,14836\n" + "760352,32,17852\n" + "770822,35,23666\n" + "580668,19,4055\n" + "436686,48,87762\n" + "32033,80,1986178\n" + "980056,9,1000\n" + "590486,6,610\n" + "601554,9,1000\n" + "355420,29,12046\n" + "529400,1,24\n" + "-1,-1\n" + "-1,-1\n" + "-1,-1\n" + "-1,-1\n" + "-1,-1\n" + "-1,-1\n" + "-1,-1\n" + "-1,-1\n" + "-1,-1";

                    await Task.Delay(1000);

                    var meh = data.Split('\n');

                    for (var i = 0; i < 24; i++)
                    {
                        var skill = (SkillTypes) i;
                        var line = meh[i].Split(',');
                        try
                        {
                            PlayerStats.Player[skill].Rank = long.Parse(line[0]);
                            PlayerStats.Player[skill].Level = long.Parse(line[1]);
                            PlayerStats.Player[skill].Exp = long.Parse(line[2]);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }

                FillStats(result);
                result.Error = $"{username} loaded successfully.";
            }
            catch (WebException wex)
            {
                var errorResponse = wex.Response as HttpWebResponse;
                if (errorResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    result.Error = $"404: {username} not found.";
                }
                else
                {
                    result.Error = "Error: Something went terribly wrong.";
                }
            }

            return result;
        }

        private static T[] EnumToArray<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            return Enum.GetValues(typeof(T)).Cast<T>().ToArray<T>();
        }

        private static void FillStats(CSVResult highscore)
        {
            foreach (var skill in EnumToArray<SkillTypes>())
            {
                highscore.Skills.Add(new SkillLevelViewModel()
                {
                    Skill = skill.ToString(),
                    Level = PlayerStats.Player[skill].Level,
                    Rank  = PlayerStats.Player[skill].Rank,
                    Xp    = PlayerStats.Player[skill].Exp
                });
            }
        }
    }
}