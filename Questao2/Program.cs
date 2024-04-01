using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class Program
{
    public static async Task Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = await GetTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = await GetTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);
    }

    public static async Task<int> GetTotalScoredGoals(string team, int year)
    {
        string apiUrl = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                FootballMatchResponse matchResponse = JsonConvert.DeserializeObject<FootballMatchResponse>(responseBody);

                int totalGoals = 0;
                foreach (var match in matchResponse.Data)
                {
                    totalGoals += match.Team1Goals;
                }
                return totalGoals;
            }
            else
            {
                // Em caso de erro na requisição, retorne -1 ou lance uma exceção, dependendo do que deseja tratar
                return -1;
            }
        }
    }
}

class FootballMatchResponse
{
    [JsonProperty("data")]
    public FootballMatch[] Data { get; set; }
}

class FootballMatch
{
    [JsonProperty("team1")]
    public string Team1 { get; set; }

    [JsonProperty("team2")]
    public string Team2 { get; set; }

    [JsonProperty("team1goals")]
    public int Team1Goals { get; set; }

    [JsonProperty("team2goals")]
    public int Team2Goals { get; set; }

    [JsonProperty("year")]
    public int Year { get; set; }
}
