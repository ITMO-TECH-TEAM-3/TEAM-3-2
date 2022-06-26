﻿using System.Net;
using System.Text;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class TournamentService
{
    public List<Guid> TeamListInTournament(Guid eventId)
    {
        // возвращает List<Guid> команд в турнире
        var request = WebRequest.Create($"https://localhost:5001/api/tournament/{eventId}/teams");
        request.Method = WebRequestMethods.Http.Get;
        var response = request.GetResponse();
        var responseStream = response.GetResponseStream();
        using var readStream = new StreamReader(responseStream, Encoding.UTF8); 
        var responseString = readStream.ReadToEnd();
        var teamList = JsonConvert.DeserializeObject<List<Guid>>(responseString);
        return teamList ?? new List<Guid>();
    }
    
    public List<Guid> TeamListInMatch(Guid eventId)
    {
        // возвращает List<Guid> команд в матче
        var request = WebRequest.Create($"https://localhost:5001/api/match/{eventId}");
        request.Method = WebRequestMethods.Http.Get;
        var response = request.GetResponse();
        var responseStream = response.GetResponseStream();
        using var readStream = new StreamReader(responseStream, Encoding.UTF8); 
        var responseString = readStream.ReadToEnd();
        var match = JsonConvert.DeserializeObject<Match>(responseString);
        var teamList = new List<Guid>();
        if (match == null)
        {
            return teamList;
        }
        teamList.Add(match.Team1Id);
        teamList.Add(match.Team2Id);
        return teamList;
    }
}