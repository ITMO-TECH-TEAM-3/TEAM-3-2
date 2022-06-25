using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace WebApplication1.Services;

public class TournamentService
{
    public List<Guid> TeamListInEvent(Guid eventId)
    {
        // возвращает List<Guid> команд в событии
        var request = WebRequest.Create($"https://localhost:5001/api/tournament/{eventId}/teams");
        request.Method = WebRequestMethods.Http.Get;
        var response = request.GetResponse();
        var responseStream = response.GetResponseStream();
        using var readStream = new StreamReader(responseStream, Encoding.UTF8); 
        var responseString = readStream.ReadToEnd();
        var teamList = JsonConvert.DeserializeObject<List<Guid>>(responseString);
        return teamList ?? new List<Guid>();
    }
}