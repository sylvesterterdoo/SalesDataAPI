# SalesDataAPI

In the project directory, you can run:

docker-compose build

docker-compose run

# API Documentation
Where the field {YY-MM-DD} represent a date like 2018-12-25

- Post sales data : POST /api/article
```json
http code 200
{
  articleNumber : value,
  SalesPrice : value2
}
```

- Number of sold articles per day : GET /api/articles/{YY-MM-DD}
    Return the number of articles sold on that day {YY-MM-DD}
    
```json
http code 200
{
  "Number of Articles " : 5, 
  "Date": 25-12-2018 
}
```

- Total revenue per day : GET /api/articles/revenues/{YY-MM-DD}
    Return the sum of prices of the articles sold on {YY-MM-DD}
```json
http code 200
{
  "Total revenue " : 1500, 
  "Date": 25-12-2018
}
```

- Statistics : Revenue grouped by articles : GET /api/articles/revenues
     Returns an aggregate count of items with the same articleNumber
     Assuming : multiple sold item can have the same article number.
```json
http code 200
[
  {
    "articleNumber": "articleNumber1",
    "count": 1,
    "total": 20.5
  },
  {
    "articleNumber": "articleNumber2",
    "count": 1,
    "total": 30.5
  },
  {
    "articleNumber": "articleNumber3",
    "count": 1,
    "total": 10.5
  },
  {
    "articleNumber": "articleNumber4",
    "count": 1,
    "total": 50.5
  }
]

