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


Статистика клиента(ClientStatisticsInfo)
| Поле      | Описание  |
|-----------|-----------|
| `UUID ClientId` | id клиента, о котором получают информацию |
| `Uint Wins` | количество выигранных ставок |
| `Uint Defeats` | количество проигранных ставок |
| `Uint TotalBetsSum` | общая сумма ставок |
| `Uint TotalWon` | общая сумма выигранных ставок |


Статистика команды(TeamStatisticsInfo)
| Поле      | Описание  |
|-----------|-----------|
| `UUID TeamId` | id клиента, о котором получают информацию |
| `Uint TotalWon` | общая сумма выигранных ставок |
| `Uint TotalBetsSum` | общая сумма сделанных на команду ставок |




## **Запросы**

### Ставка на матч

Ставка на то, какая из команд победит в матче

Http запрос
`POST /create/match`

Пример использования с curl

`curl -X 'POST' \
  'https://localhost:7191/create/match?clientId=8df4174b-697b-4f59-a202-614ff124f1ef  &sum=123&eventId=8df4174b-697b-4f59-a202-614ff124f1ef&teamId=8df4174b-697b-4f59-a202-614ff124f1ef' \
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

Пример использования с curl

`curl -X 'POST' \
  'https://localhost:7191/create/tournament?clientId=2728e16b-74bc-46ef-8e85-eb1d97216040&sum=123&eventId=2728e16b-74bc-46ef-8e85-eb1d97216040&teamId=2728e16b-74bc-46ef-8e85-eb1d97216040' \
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

Пример использования с curl

`curl -X 'GET' \
  'https://localhost:7191/info/event?eventId=2728e16b-74bc-46ef-8e85-eb1d97216040' \
  -H 'accept: */*'`

eventId - id события, информацию о котором нужно получить

Возвращаемое значение

Сущность - информация о событии



### Информация о сделанных клиентом ставках на матчи

Http запрос
`GET /info/client/bets/match`

Пример использования с curl

`curl -X 'GET' \
  'http://172.18.0.3:5000/info/client/bets/match?clientId=9ff2f7e3-34a3-4675-826f-d387120d4a5d' \
  -H 'accept: */*'`

clientId - id клиента, о котором нужно получить информацию

Возвращаемое значение

`List<EventInfo> eventInfoList` - лист с информацией о событиях



### Информация о сделанных клиентом ставках на турниры

Http запрос
`GET /info/client/bets/tournament`

Пример использования с curl

`curl -X 'GET' \
  'https://localhost:7191/info/client/bets/tournament?clientId=9ff2f7e3-34a3-4675-826f-d387120d4a5d' \
  -H 'accept: */*'`

clientId - id клиента, о котором нужно получить информацию

Возвращаемое значение

`List<EventInfo> eventInfoList` - лист с информацией о событиях



### Статистика клиента

Http запрос
`GET /statistics/client`

Пример использования с curl

`curl -X 'GET' \
  'https://localhost:7191/statistics/client?clientId=2728e16b-74bc-46ef-8e85-eb1d97216040' \
  -H 'accept: */*'`

clientId - id клиента, статистику которого нужно получить

Возвращаемое значение

Сущность - статистика клиента


### Статистика команды

Http запрос
`GET /statistics/team`

Пример использования с curl

`curl -X 'GET' \
  'https://localhost:7191/statistics/team?teamId=2728e16b-74bc-46ef-8e85-eb1d97216040' \
  -H 'accept: */*'`

teamId - id команды, статистику которой нужно получить

Возвращаемое значение

Сущность - статистика команды

