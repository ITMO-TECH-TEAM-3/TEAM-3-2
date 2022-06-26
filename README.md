# TEAM-3-2

**1.Возможность сделать ставку на исход турнира / матча**

**2.Перерасчет коэффициентов после каждой ставки**

Метод автоматически пересчитывает коэффициенты после каждой сделанной пользователем ставки.

**3.Запрет ставок на события, в которых пользователь принимает участие**

При попытке сделать ставку на себя / команду, в которой состоит пользователь, ставка не производится 

**4.Статистика ставок**

**5.Информация о событии и ставках**


## **Возращаемые сущности**

Ставка на матч(BetMatch)
| Поле      | Описание  |
|-----------|-----------|
| `UUID Id` | id ставки |
| `UUID ClietnId` | id клиента, который делает ставку |
| `UUID EventId` | id события, на которое делается ставка |
| `Uint Sum` | сумма ставки |
| `UUID TeamId` | id команды, на которую делается ставка |
| `BetResult Result` | статус ставки [ `Lose, Win, InProgress` ] |


Ставка на турнир(BetTournament)
| Поле      | Описание  |
|-----------|-----------|
| `UUID Id` | id ставки |
| `UUID ClietnId` | id клиента, который делает ставку |
| `UUID EventId` | id события, на которое делается ставка |
| `Uint Sum` | сумма ставки |
| `UUID TeamId` | id команды, на которую делается ставка |
| `BetResult Result` | статус ставки [ `Lose, Win, InProgress` ] |


Информация о событии(EventInfo)
| Поле      | Описание  |
|-----------|-----------|
| `UUID Id` | id информации о событии |
| `UUID EventId` | id события, на которое делается ставка |
| `Double Coefficient` | коэффициент на событие |
| `UUID TeamId` | id команды, на которую была сделана ставка |
| `Uint Place` | место, которая должна занять команда согласно ставке |
| `EventResult Result` | статус события [ `Lose, Win, Draw, NotStarted, InProgress` ] |



## **Запросы**

### Ставка на матч

Ставка на то, какая из команд победит в матче

Http запрос
`POST /create/match`

Curl

`curl -X 'POST' \
  'https://localhost:7191/create/match
  ?clientId=8df4174b-697b-4f59-a202-614ff124f1ef  
  &sum=123
  &eventId=8df4174b-697b-4f59-a202-614ff124f1ef
  &teamId=8df4174b-697b-4f59-a202-614ff124f1ef' \
  -H 'accept: */*' \
  -d ''`

clientId - id клиента, который хочет сделать ставку
sum - сумма ставки
eventId - id события, на которое делается ставка
teamId - id команды, на которую делается ставка

Возвращаемое значение
Сущность - ставка на матч



### Ставка на турнир

Ставка на то, какая из команд займет первое место в турнире

Http запрос
`POST /create/tournament`

Curl

`curl -X 'POST' \
  'https://localhost:7191/create/tournament
  ?clientId=2728e16b-74bc-46ef-8e85-eb1d97216040
  &sum=12
  3&eventId=2728e16b-74bc-46ef-8e85-eb1d97216040
  &teamId=2728e16b-74bc-46ef-8e85-eb1d97216040' \
  -H 'accept: */*' \
  -d ''`
  
clietnId - id клиента, который хочет сделать ставку
sum - сумма ставки
eventId - id события, на которое делается ставка
teamId - id команды, на которую делается ставка

Возвращаемое значение
Сущность - ставка на турнир



### Информация о событии

Http запрос
`GET /info/event`

Curl

curl -X 'GET' \
  'https://localhost:7191/info/event?eventId=2728e16b-74bc-46ef-8e85-eb1d97216040' \
  -H 'accept: */*'

Возвращаемое значение
`EventInfo eventInfo` - информация о событии

```
{
  "id": "8df4174b-697b-4f59-a202-614ff124f1ef",
  "eventId": "4f68f672-d310-47ce-b20c-7d308f436c58",
  "coefficient": "1",
  "teamId": "9ff2f7e3-34a3-4675-826f-d387120d4a5d",
  "result": "2",
  "totalSum": "100"
}
```
clietnId - id клиента, который хочет сделать ставку
sum - сумма ставки
eventId - id события, на которое делается ставка
teamId - id команды, на которую делается ставка
totalSum - сумма всех ставок на данное событие



### Информация о сделанных клиентом ставках на матчи

Http запрос
`GET /info/client/bets/match`

Пример использования с curl

curl -X 'GET' \
  'http://172.18.0.3:5000/info/client/bets/match?clientId=9ff2f7e3-34a3-4675-826f-d387120d4a5d' \
  -H 'accept: */*'

Возвращаемое значение
`List<EventInfo> eventInfoList` - лист с информацией о событиях



### Информация о сделанных клиентом ставках на турниры

Http запрос
`GET /info/client/bets/tournament`

Тело запроса

```
{
  "clietnId": "9ff2f7e3-34a3-4675-826f-d387120d4a5d"
}
```

Возвращаемое значение
`List<EventInfo> eventInfoList` - лист с информацией о событиях



### Статистика клиента

Http запрос
`GET /statistics/client`

Тело запроса

```
{
  "clietnId": "9ff2f7e3-34a3-4675-826f-d387120d4a5d"
}
```

Возвращаемое значение
`ClientStatisticsInfo clientStatisticsInfo` - статистика клиента
```
{
  "clientId": "4c8e23ac-e312-42b9-931c-9e9d929cd1cf",
  "wins": 0,
  "defeats": 0,
  "totalBetsSum": 480,
  "totalWon": 0
}
```



### Статистика клиента

Http запрос
`GET /statistics/client`

Тело запроса

```
{
  "teamId": "9ff2f7e3-34a3-4675-826f-d387120d4a5d"
}
```

Возвращаемое значение
`TeamStatisticsInfo teamStatisticsInfo` - статистика клиента
```
{
  "teamId": "4c8e23ac-e312-42b9-931c-9e9d929cd1ee",
  "totalWon": 0,
  "totalBetsSum": 159
}
```
