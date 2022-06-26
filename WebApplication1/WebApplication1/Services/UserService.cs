using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace WebApplication1.Services;

public class UserService
{
    public List<Guid> UserListInTeam(Guid teamId)
    {
        var url = Environment.GetEnvironmentVariable("USERS_SERVICE_URL");
        if (url == string.Empty) return new List<Guid>();
        var request = WebRequest.Create($"http://{url}/players-rest/all/?id={teamId}");
        request.Method = WebRequestMethods.Http.Get;
        var response = request.GetResponse();
        var responseStream = response.GetResponseStream();
        using var readStream = new StreamReader(responseStream, Encoding.UTF8); 
        var responseString = readStream.ReadToEnd();
        var usersList = JsonConvert.DeserializeObject<List<Guid>>(responseString);
        return usersList ?? new List<Guid>();
    }
}