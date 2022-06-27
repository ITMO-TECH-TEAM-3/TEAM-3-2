using System.Net;
using System.Text;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class UserService
{
    public List<Guid> UserListInTeam(Guid teamId)
    {
        var url = Environment.GetEnvironmentVariable("USERS_SERVICE_URL");
        if (url == string.Empty) return new List<Guid>();
        var request = WebRequest.Create($"http://{url}/teams-rest/{teamId}/players");
        request.Method = WebRequestMethods.Http.Get;
        var response = request.GetResponse();
        var responseStream = response.GetResponseStream();
        using var readStream = new StreamReader(responseStream, Encoding.UTF8); 
        var responseString = readStream.ReadToEnd();
        var playersList = JsonConvert.DeserializeObject<List<PlayerInfo>>(responseString);
        if (playersList == null) return new List<Guid>();
        var usersList = playersList.Select(player => player.UserId).ToList();
        return usersList;
    }
}